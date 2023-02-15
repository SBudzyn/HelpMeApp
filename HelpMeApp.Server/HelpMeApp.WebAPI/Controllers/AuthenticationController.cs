using FluentValidation;
using FluentValidation.Results;
using HelpMeApp.Services.Interfaces;
using HelpMeApp.Services.Models.Login;
using HelpMeApp.Services.Models.Registration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMeApp.WebAPI.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _authenticationService;
        private IValidator<RegistrationRequestModel> _registrationValidator;

        public AuthenticationController(IAuthenticationService authenticationService, IValidator<RegistrationRequestModel> registrationValidator)
        {
            _authenticationService = authenticationService;
            _registrationValidator = registrationValidator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestModel registrationData)
        {
            ValidationResult validationResult = _registrationValidator.Validate(registrationData);

            if (!validationResult.IsValid)
            {
                var modelStateDictionary = new ModelStateDictionary();

                foreach (ValidationFailure failure in validationResult.Errors)
                {
                    modelStateDictionary.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }

                return ValidationProblem(modelStateDictionary);
            }

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
