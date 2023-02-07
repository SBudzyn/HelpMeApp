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
using HelpMeApp.Services.MappingProfiles;

namespace HelpMeApp.Services.Services.Profile
{
    public class ProfileService : IProfileService
    {
        private UserManager<AppUser> _userManager;
        private IMapper _mapper;

        public ProfileService(UserManager<AppUser> userManager, IMapper mapper)
        {
            this._userManager = userManager;
            this._mapper = mapper;
        }

        public async Task<ProfileResponseModel<ProfileRequestModel>> GetUserById(string userId)
        {
            var response = new ProfileResponseModel<ProfileRequestModel>();
            AppUser foundedUser = await _userManager.FindByIdAsync(userId);
            if (foundedUser == null)
            {
                response.Success = false;
                response.Message = "Sorry, your account was not found";
                return response;
            }
            else
            {
                var user = _mapper.Map<ProfileRequestModel>(foundedUser);
                response.Data = user;
                response.Success = true;
                response.Message = "Your account was found";

            }
            return response;
        }
    }
}
