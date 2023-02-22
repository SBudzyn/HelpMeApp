using AutoMapper;
using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;
using HelpMeApp.Services.Helpers;
using HelpMeApp.Services.Interfaces;
using HelpMeApp.Services.Models.Login;
using HelpMeApp.Services.Models.Registration;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private ITokenService _tokenService;
        private IMapper _mapper;

        public AuthenticationService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        
        public async Task<RegistrationResponseModel> RegisterAsync(RegistrationRequestModel registrationData)
        {
            var user = _mapper.Map<AppUser>(registrationData);
            user.Photo = ImageConvertorHelper.ConvertToBase64(registrationData.Photo);
            user.PhotoPrefix = ImageConvertorHelper.GetImagePrefix(registrationData.Photo);

            user.RegistrationDate= DateTime.Now;

            var result = await _userManager.CreateAsync(user, registrationData.Password);

            var response = new RegistrationResponseModel() { IsSuccessful = false, Message = String.Empty };

            if (result.Succeeded)
            {
                response.IsSuccessful = true;
                return response;
            }

            response.Message = result.Errors.FirstOrDefault()?.Description; 
            return response;
        }

        public async Task<LoginResponseModel> LoginAsync(LoginRequestModel loginData)
        {
            var user = await _userManager.FindByEmailAsync(loginData.Email);

            var response = new LoginResponseModel() { IsSuccessful = false };

            if (user == null || user.IsBlocked == true)
            {
                return response;
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginData.Password, true, false);

            if (result.Succeeded)
            {
                response.IsSuccessful = true;
                response.Token = _tokenService.GenerateToken(user);
                response.UserId = user.Id;
            }

            return response;
        }
    }
}
