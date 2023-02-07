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
            // _signInManager = signInManager;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
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

        public async Task<ProfileResponseModel<ProfileEditionModel>> UpdateUser(string userId, ProfileEditionModel profileEditionModel)
        {
            var response = new ProfileResponseModel<ProfileEditionModel>();
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
                return response;
            }
            else
            {
                response.Success = false;
                response.Message = "Sorry, your account was not updated";
                return response;
            }
        }

        public async Task<ProfileResponseModel<ProfileEditionModel>> DeleteUser(string userId)
        {
            var response = new ProfileResponseModel<ProfileEditionModel>();
            AppUser foundedUser = await _userManager.FindByIdAsync(userId);
            if (foundedUser.IsBlocked == true)
            {
                response.Success = false;
                response.Message = "User is already blocked";
                return response;
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
                return response;
            }
        }
    }
}