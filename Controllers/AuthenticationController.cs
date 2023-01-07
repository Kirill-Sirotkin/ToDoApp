using Microsoft.AspNetCore.Mvc;
using ToDoApp.Entities;
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
        public IActionResult SignUp(AuthenticationRequest request)
        {
            var (success, content) = _authenticationService.SignUp(request._email, request._password);
            if (!success) { return BadRequest(content); }

            return SignIn(request);
        }
        [HttpPost("signin")]
        public IActionResult SignIn(AuthenticationRequest request)
        {
            var (success, content) = _authenticationService.SignIn(request._email, request._password);
            if (!success) { return BadRequest(content); }

            return Ok(new AuthenticationResponse() {_token = content});
        }
    }
}