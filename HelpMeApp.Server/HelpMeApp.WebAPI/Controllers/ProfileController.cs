using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using HelpMeApp.Services.Models.Profile;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using System.Collections.Generic;
using HelpMeApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using HelpMeApp.Services.Services.Profile;

namespace HelpMeApp.WebAPI.Controllers.Profile
{
    [Route("api/profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private IProfileService _profileService;

        public ProfileController(UserManager<AppUser> userManager, IProfileService profileService)
        {
            this._userManager = userManager;
            this._profileService = profileService;
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<ProfileResponseModel<ProfileRequestModel>>> GetUserById(string id)
        {
            var result = await _profileService.GetUserById(id);
            return result;
        }
    }
}