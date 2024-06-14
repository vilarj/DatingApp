using System.Security.Cryptography;
using System.Text;
using DatingApp.Data;
using DatingApp.DTOs;
using DatingApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Controllers
{
    public class AccountController : BaseApiController {
        private readonly DatingAppDbContext _context;

        public AccountController(DatingAppDbContext context) {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterUserAsync(RegisterDTO registerDto) {
            
            if (await UserExistsAsync(registerDto.UserName)) {
                return BadRequest($"The following username is taken: {registerDto.UserName}\nTry with a different one.");
            }

            using var hmac = new HMACSHA512();

            var user = new User() {
                UserName = registerDto.UserName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private async Task<bool> UserExistsAsync(string username) {
            return await _context.Users.AnyAsync(user => user.UserName == username.ToLower());
        }

    }
}