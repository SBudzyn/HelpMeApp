using AutoMapper;
using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;
using HelpMeApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HelpMeApp.Services.Interfaces.Profile;
using HelpMeApp.Services.Models.Profile;
using HelpMeApp.Services.DTO;
using Microsoft.EntityFrameworkCore;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Entities.ChatEntity;
using HelpMeApp.DatabaseAccess.Entities.ReportEntity;
using HelpMeApp.Services.MappingProfiles;
using Azure;

namespace HelpMeApp.Services.Services.Profile
{
    public class ProfileService : IProfileService
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;       
        private IMapper _mapper;
        public ProfileService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper)
        {            
            _userManager = userManager;
            // _signInManager = signInManager;
            _mapper = mapper;

        }
        public async Task<ProfileResponseModel<ProfileRequestModel>> GetUserById(string userId)
        {
            var response = new ProfileResponseModel<ProfileRequestModel>();         
            var foundedUser = await _userManager.FindByIdAsync(userId);            
            var user = new ProfileRequestModel();
            // var user = _mapper.Map<ProfileRequestModel>(foundedUser);
            if (foundedUser == null)
            {
                response.Success = false;
                response.Message = "Sorry, your account was not founded";
                return response;
            }
            else
            {
                response.Success = true;
                response.Message = "Your account was founded";
                user.Id = foundedUser.Id;
                user.Username= foundedUser.Name;
                user.Name = foundedUser.Name;
                user.Email = foundedUser.Email;
                user.Surname = foundedUser.Surname;
                user.Photo = foundedUser.Photo;
                user.Info = foundedUser.Info;
                user.IsBlocked = foundedUser.IsBlocked;
                user.Adverts = foundedUser.Adverts;
                user.Chats = foundedUser.Chats;
                user.PasswordHash = foundedUser.PasswordHash;
                user.RegistrationDate = foundedUser.RegistrationDate;
                user.Reports = foundedUser.Reports;
                response.Data = user;
            }
            return response;

        }
        public async Task<ProfileResponseModel<ProfileRequestModel>> GetUserById(string userId) { 
            
        }

    }
}
