using AutoMapper;
using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;
using HelpMeApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpMeApp.Services.Models.Profile;
using Microsoft.EntityFrameworkCore;

namespace HelpMeApp.Services.Services
{
    public class ProfileService : IProfileService
    {
        private UserManager<AppUser> _userManager;
        private IMapper _mapper;
        private IPasswordHasher<AppUser> _passwordHasher;

        public ProfileService(UserManager<AppUser> userManager, IMapper mapper, IPasswordHasher<AppUser> passwordHasher)
        {
            _userManager = userManager;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }
        public async Task<ProfileResultMessagesData<ProfileResponceData>> GetUserById(string userId)
        {
            var response = new ProfileResultMessagesData<ProfileResponceData>();
            AppUser foundedUser = await _userManager.FindByIdAsync(userId);

            if (foundedUser == null)
            {
                response.Success = false;
                response.Message = "Sorry, your account was not founded";
            }
            else
            {
                var user = _mapper.Map<ProfileResponceData>(foundedUser);
                response.Data = user;
                response.Success = true;
                response.Message = "Your account was founded";
            }
            return response;
        }

        public async Task<ProfileResultMessagesData<ProfileEditionModel>> UpdateUser(string userId, ProfileEditionModel profileEditionModel)
        {
            var response = new ProfileResultMessagesData<ProfileEditionModel>();
            AppUser foundedUser = await _userManager.FindByIdAsync(userId);
            var passwordHashVeryfication = _passwordHasher.VerifyHashedPassword(foundedUser, foundedUser.PasswordHash, profileEditionModel.PasswordHash);
            if (passwordHashVeryfication == PasswordVerificationResult.Failed)
            {
                foundedUser.PasswordHash = _passwordHasher.HashPassword(foundedUser, profileEditionModel.PasswordHash);
                profileEditionModel.PasswordWasHashed = true;
            }
            var mappingEditionModelAppUser = _mapper.Map(profileEditionModel, foundedUser);
            var updateUserData = await _userManager.UpdateAsync(foundedUser);
            if (updateUserData.Succeeded)
            {
                response.Success = true;
                response.Message = "Your account was updated successfully";
            }
            else
            {
                response.Success = false;
                response.Message = "Sorry, your account was not updated";                
            }
            return response;
        }

        public async Task<ProfileResultMessagesData<ProfileEditionModel>> DeleteUser(string userId)
        {
            var response = new ProfileResultMessagesData<ProfileEditionModel>();
            AppUser foundedUser = await _userManager.FindByIdAsync(userId);
            if (foundedUser.IsBlocked == true)
            {
                response.Success = false;
                response.Message = "User is already blocked";
            }
            else
            {
                foundedUser.IsBlocked = true;
                var updateUserData = await _userManager.UpdateAsync(foundedUser);
                if (updateUserData.Succeeded)
                {
                    response.Success = true;
                    response.Message = "User is blocked successfully";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Sorry, user was not blocked successfully";
                }             
            }
            return response;
        }
    }
}