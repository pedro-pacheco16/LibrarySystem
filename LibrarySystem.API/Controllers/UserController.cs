using LibrarySystem.Application.Models;
using LibrarySystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserInputModel userModel)
        {
            var result = _userService.CreateUser(userModel);

            return Ok(result);
        }
    }
}
