using LibrarySystem.API.Entities;
using LibrarySystem.API.Models;
using LibrarySystem.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly LibrarySystemDbContext _context;

        public UserController(LibrarySystemDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Users.ToList();

            var model = users.Select(user => new UserViewModel(user.Name, user.Email)).ToList();

            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserInputModel userModel)
        {
            var user = new User(userModel.Name, userModel.Email);


            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok();
        }
    }
}
