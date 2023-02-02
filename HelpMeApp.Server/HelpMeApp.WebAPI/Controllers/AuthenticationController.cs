using HelpMeApp.Services.Interfaces;
using HelpMeApp.Services.Models.Login;
using HelpMeApp.Services.Models.Registration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HelpMeApp.WebAPI.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegistrationRequestModel registrationData)
        {
            var result = await _authenticationService.RegisterAsync(registrationData);
            
            return result.IsSuccessful ? CreatedAtAction(nameof(Register), result) : BadRequest(result);
             
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel loginData)
        {
            var result = await _authenticationService.LoginAsync(loginData);

            return result.IsSuccessful ? Ok(result) : Unauthorized(result);
        }
    }
}
