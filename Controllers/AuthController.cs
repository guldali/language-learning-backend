using Microsoft.AspNetCore.Mvc;
using YourNamespace.Services;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _userService.RegisterUser(model.Email, model.Password);

            if (result)
            {
                return Ok(new { message = "Registration successful" });
            }
            else
            {
                return BadRequest(new { message = "Email is already registered" });
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _userService.GetUserByEmail(model.Email);

            if (user == null || user.Password != model.Password)
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }

            return Ok(new { message = "Login successful", id = user.Id });
        }
    }
}
