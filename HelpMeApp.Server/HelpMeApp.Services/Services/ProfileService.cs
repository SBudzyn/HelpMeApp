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
using HelpMeApp.Services.Models.Advert;
using HelpMeApp.Services.Services;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Interfaces;
using HelpMeApp.Services.Helpers;

namespace HelpMeApp.Services.Services
{
    public class ProfileService : IProfileService
    {
        private UserManager<AppUser> _userManager;
        private IMapper _mapper;
        private IPasswordHasher<AppUser> _passwordHasher;
        private IAdvertService _advertService;
        private IAdvertReadRepository _advertReadRepository;

        public ProfileService(UserManager<AppUser> userManager, IMapper mapper, IPasswordHasher<AppUser> passwordHasher, IAdvertService advertService, IAdvertReadRepository advertReadRepository)
        {
            _userManager = userManager;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _advertService = advertService;
            _advertReadRepository = advertReadRepository;
        }

        public async Task<ProfileResponseData> GetUserByIdAsync(string userId)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);

            var advertsUserCanHelp = await _advertReadRepository.CountAdvertsUserCanHelpAsync(userId);

            var userData = _mapper.Map<ProfileResponseData>(user);

            userData.UserHelpCount = advertsUserCanHelp;

            userData.Photo = ImageConvertorHelper.ConvertPhotoToString(user.PhotoPrefix, user.Photo);

            return userData;
        }

        public async Task<ProfileResultMessageModel> UpdateUserAsync(string userId, ProfileUpdateData profileUpdateData)
        {
            var result = new ProfileResultMessageModel();
            AppUser user = await _userManager.FindByIdAsync(userId);

            PasswordVerificationResult passwordHashVerification;
            if (profileUpdateData.Password != null)
            {
                passwordHashVerification = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, profileUpdateData.Password);

                if (passwordHashVerification == PasswordVerificationResult.Failed)
                {

                    profileUpdateData.Password = _passwordHasher.HashPassword(user, profileUpdateData.Password);
                }
                else
                {
                    profileUpdateData.Password = user.PasswordHash;
                }
            }
            else
            {
                profileUpdateData.Password = user.PasswordHash;
            }

            var mappingEditionModelAppUser = _mapper.Map(profileUpdateData, user);

            var updateUserData = await _userManager.UpdateAsync(user);
            if (updateUserData.Succeeded)
            {
                result.Success = true;
                result.Message = "Your account has been updated successfully";
            }
            else
            {
                result.Success = false;
                result.Message = "An error has occurred. The data has not been updated";
            }
            return result;
        }

        public async Task<ProfileResultMessageModel> DeleteUserAsync(string userId)
        {
            var result = new ProfileResultMessageModel();
            AppUser user = await _userManager.FindByIdAsync(userId);

            if (user != null && user.IsBlocked == false)
            {
                user.IsBlocked = true;
                var updateUserData = await _userManager.UpdateAsync(user);
                if (updateUserData.Succeeded)
                {
                    result.Success = true;
                    result.Message = "Your account has been deleted successfully";
                }
                else
                {
                    result.Success = false;
                    result.Message = "An error has occurred. Your account has not been deleted";
                }
                return result;
            }

            result.Success = false;
            result.Message = "User is already deleted";
            return result;
        }

        public async Task<IEnumerable<AdvertPreviewResponseData>> GetUserNeedsHelpAdvertsByPageAsync(string userId, int page, int pageSize)
        {
            var userAdverts = await _advertReadRepository.GetUserNeedsHelpAdvertsByPageAsync(userId, page, pageSize);

            var advertsData = _mapper.Map<IEnumerable<AdvertPreviewResponseData>>(userAdverts);

            return advertsData;
        }
    }
}
