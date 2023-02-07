using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using HelpMeApp.Services.Models.Profile;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using HelpMeApp.Services.Interfaces;

namespace HelpMeApp.WebAPI.Controllers
{
    [Route("api/profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private IProfileService _profileService;

        public ProfileController(UserManager<AppUser> userManager, IProfileService profileService)
        {
            _userManager = userManager;
            _profileService = profileService;
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<ProfileResponseModel<ProfileRequestModel>>> GetUserById(string id)
        {
            var result = await _profileService.GetUserById(id);
            return result;
        }

        [HttpPut("UpdateUser/{userId}")]
        [Authorize]
        public async Task<ActionResult<ProfileResponseModel<ProfileEditionModel>>> Update(string userId, [FromBody] ProfileEditionModel profileEditionModel)
        {
            if (await _userManager.FindByIdAsync(userId) == null)
            {
                return NotFound();
            }
            var result = await _profileService.UpdateUser(userId, profileEditionModel);
            return result;
        }

        [HttpGet("DeleteUser/{userId}")]
        [Authorize]
        public async Task<ActionResult<ProfileResponseModel<ProfileEditionModel>>> DeleteUser(string userId)
        {
            if (await _userManager.FindByIdAsync(userId) == null)
            {
                return NotFound();
            }
            var result = await _profileService.DeleteUser(userId);
            return result;
        }

    }
}