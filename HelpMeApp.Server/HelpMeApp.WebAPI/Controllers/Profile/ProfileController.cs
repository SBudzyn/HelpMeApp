using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using HelpMeApp.Services.Models.Profile;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using System.Collections.Generic;
using HelpMeApp.Services.Interfaces.Profile;
using Microsoft.AspNetCore.Authorization;

namespace HelpMeApp.WebAPI.Controllers.Profile
{  
    [Route("api/profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private IProfileService _profileService;
        private IAuthorizationService _authorizationService;

        public ProfileController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IProfileService profileService, IAuthorizationService authorizationService)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._profileService = profileService;
            this._authorizationService = authorizationService;
            
        }
        
        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<ProfileResponseModel<ProfileRequestModel>>> GetUserById(string id) {
            var result = await _profileService.GetUserById(id);          
            return result;

        }
        /*
        [HttpPut("UpdateUser/{userId}")]
        public async Task<ActionResult<ProfileResponseModel<ProfileEditionModel>>> Update(string userId, [FromBody] ProfileEditionModel profileEditionModel)
        {
            if (await _profileService.GetUserById(userId) == null)
            {
                return NotFound();
            }
            
            var authorizationResult = await _authorizationService.AuthorizeAsync(User, userId, "EditPolicy");
            if (!authorizationResult.Succeeded)
            {
                return Unauthorized("You don`t have permission to modify the resource");
            }
            
            var result = await _profileService.UpdateUser(userId, profileEditionModel);
            return result;
        }
        [HttpGet("DeleteUser/{userId}")]
        public async Task<ActionResult<ProfileResponseModel<ProfileEditionModel>>> DeleteUser(string userId)
        {
            if (await _profileService.GetUserById(userId) == null)
            {
                return NotFound();
            }
            var result = await _profileService.DeleteUser(userId);
            return result;
        } */

    }
}
