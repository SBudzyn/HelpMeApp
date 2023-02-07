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
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace HelpMeApp.Services.Services.Profile
{
    public class ProfileService : IProfileService
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private IMapper _mapper;
        private IPasswordHasher<AppUser> _passwordHasher;

        
        public ProfileService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IPasswordHasher<AppUser> passwordHasher)
        {            
            this._userManager = userManager;
            // _signInManager = signInManager;
            this._mapper = mapper;
            this._passwordHasher = passwordHasher;
        }
        public async Task<ProfileResponseModel<ProfileRequestModel>> GetUserById(string userId)
        {
            var response = new ProfileResponseModel<ProfileRequestModel>();
            AppUser foundedUser = await _userManager.FindByIdAsync(userId);
            //var user = new ProfileRequestModel();
            
            if (foundedUser == null)
            {
                response.Success = false;
                response.Message = "Sorry, your account was not founded";
                return response;
            }
            else
            {
                var user = _mapper.Map<ProfileRequestModel>(foundedUser);
                response.Data = user;
                
                response.Success = true;
                response.Message = "Your account was founded";
                
            }
            return response;

        }

        //Can I return null ProfileResponseModel.Data or I should create new model?
        /*
        public async Task<ProfileResponseModel<ProfileEditionModel>> UpdateUser(string userId, ProfileEditionModel profileEditionModel)
        {
            var response = new ProfileResponseModel<ProfileEditionModel>();
            AppUser foundedUser = await _userManager.FindByIdAsync(userId);
            
            if(profileEditionModel.PasswordHash != foundedUser.PasswordHash)
            {
                foundedUser.PasswordHash = _passwordHasher.HashPassword(foundedUser, profileEditionModel.PasswordHash);
            }           
            var mappingEditionModelAppUser = _mapper.Map(profileEditionModel, foundedUser);
            var updateUserData = await _userManager.UpdateAsync(foundedUser);
            if (updateUserData == null)
            {
                response.Success = true;
                response.Message = "Your account was updated successfully";
                return response;
            }
            else
            {
                response.Success = false;
                response.Message = "Sorry, your account was not updated";
                return response;
            }
        }

        //Does already blocked user can click on Delete account?
        //Should I Save data changes or AppUser saves it by default?

        public async Task<ProfileResponseModel<ProfileEditionModel>> DeleteUser(string userId)
        {
            var response = new ProfileResponseModel<ProfileEditionModel>();
            AppUser foundedUser = await _userManager.FindByIdAsync(userId);
            if(foundedUser.IsBlocked = true){
                response.Success = false;
                response.Message = "User is already blocked";
                return response;
            }
            else
            {
                
                foundedUser.IsBlocked = true;
                var updateUserData = _userManager.UpdateAsync(foundedUser);
                
                if(updateUserData == null) 
                response.Success = true;
                response.Message = "User is blocked successfully";
                return response;
            }
           
            
        } */

    }
}
