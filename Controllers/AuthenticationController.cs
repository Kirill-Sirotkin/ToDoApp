using Microsoft.AspNetCore.Mvc;
using ToDoApp.Services;

namespace ToDoApp.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

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