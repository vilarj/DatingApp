using System.Security.Cryptography;
using System.Text;
using DatingApp.Data;
using DatingApp.DTOs;
using DatingApp.Entities;
using DatingApp.Interfaces;
// using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Controllers
{
    // [Authorize]
    public class AccountController : BaseApiController
    {
        private readonly DatingAppDbContext _context;
        private readonly ITokenService _tokenServive;

        public AccountController(DatingAppDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenServive = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> RegisterUserAsync(RegisterDTO registerDto)
        {
            // Checking if the username exist for the specific username            
            if (await UserExistsAsync(registerDto.UserName))
            {
                return BadRequest($"The following username is taken: {registerDto.UserName}\nTry with a different one.");
            }

            using var hmac = new HMACSHA512();

            var user = new User()
            {
                UserName = registerDto.UserName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDTO
            {
                UserName = user.UserName,
                Token = _tokenServive.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _context.Users.SingleOrDefaultAsync(user => user.UserName == loginDTO.UserName);

            // Checking if the username is valid
            if (user == null) return Unauthorized($"Invalid Username: {loginDTO.UserName}");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

            // Checking if the passwords match
            for (int i = 0; i < computedHash.Length; i++)
            {
                // if passwords don't match, throw unauthorized message + code
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
            }

            return new UserDTO
            {
                UserName = user.UserName,
                Token = _tokenServive.CreateToken(user)
            };
        }

        /// <summary>
        ///     Checks whether a username already exist in the database.
        /// </summary>
        /// <param name="username">
        ///     username to be checked against the usernames in the database.
        /// </param>
        /// <returns>
        ///     true/false
        /// </returns>
        private async Task<bool> UserExistsAsync(string username)
        {
            return await _context.Users.AnyAsync(user => user.UserName == username.ToLower());
        }

    }
}