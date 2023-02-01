using HelpMeApp.Services.Models.Login;
using HelpMeApp.Services.Models.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginResponseModel> LoginAsync(LoginRequestModel loginData);
        Task<RegistrationResponseModel> RegisterAsync(RegistrationRequestModel registrationData);
    }
}
