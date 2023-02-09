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
using HelpMeApp;

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

        public async Task<ProfileResponseData> GetUserById(string userId)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);

            var userData = _mapper.Map<ProfileResponseData>(user);

            return userData;
        }

        public async Task UpdateUser(string userId, ProfileResponseData profileResponseData)
        {
            
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null) {

                var passwordHashVeryfication = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, profileResponseData.Password);
                if (passwordHashVeryfication == PasswordVerificationResult.Failed)
                {
                    profileResponseData.Password = _passwordHasher.HashPassword(user, profileResponseData.Password);
                }
                else
                {
                    profileResponseData.Password = user.PasswordHash;
                }

                var mappingEditionModelAppUser = _mapper.Map(profileResponseData, user);
                var updateUserData = await _userManager.UpdateAsync(user);
            }
        }

        public async Task DeleteUser(string userId)
        {          
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                if (user.IsBlocked == false)
                {
                    var mapToAppUser = _mapper.Map<ProfileResponseData>(user);

                    user.IsBlocked = true;

                    var updateUserData = await _userManager.UpdateAsync(user);
                }
            }          
        }
    }
}