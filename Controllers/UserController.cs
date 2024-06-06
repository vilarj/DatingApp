

using DatingApp.Data;
using DatingApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DatingAppDbContext _context;

        public UserController(DatingAppDbContext context) {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers() {
            return _context.Users.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id) {
            return _context.Users.Find(id);
        }
    }
}