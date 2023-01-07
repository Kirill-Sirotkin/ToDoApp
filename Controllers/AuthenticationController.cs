using Microsoft.AspNetCore.Mvc;

namespace ToDoApp.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("signup")]
        public IActionResult SignUp(string email, string password)
        {
            return Unauthorized();
        }
        [HttpPost("signin")]
        public IActionResult SignIn(string email, string password)
        {
            return Unauthorized();
        }
    }
}