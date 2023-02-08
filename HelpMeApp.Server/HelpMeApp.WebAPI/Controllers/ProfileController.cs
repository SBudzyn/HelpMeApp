using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using HelpMeApp.Services.Models.Profile;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using HelpMeApp.Services.Interfaces;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.WebAPI.Authorization;
namespace HelpMeApp.WebAPI.Controllers
{
    [Route("api/profile")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private IProfileService _profileService;
        private IAuthorizationService _authorizationService;

        public UserController(UserManager<AppUser> userManager, IProfileService profileService, IAuthorizationService authorizationService)
        {
            _authorizationService= authorizationService;
            _userManager = userManager;
            _profileService = profileService;
        }
        [Authorize]
        [HttpGet("GetUserById/{userId}")]
        public async Task<ActionResult<ProfileResponceData>> GetUserById(string userId)
        {
            if (await _userManager.FindByIdAsync(userId) != null)
            {
                var authorizationResult = await _authorizationService.AuthorizeAsync(User, userId, "EditPolicy");

                if (authorizationResult.Succeeded)
                {
                    return await _profileService.GetUserById(userId);
                }

            }
            return Unauthorized("You don`t have permission to modify the resource");          
        }

        [Authorize]
        [HttpPut("UpdateUser/{userId}")]
        public async Task Update(string userId, [FromBody] ProfileResponceData profileResponceData)
        {
            if (await _userManager.FindByIdAsync(userId) != null)
            {
                var authorizationResult = await _authorizationService.AuthorizeAsync(User, userId, "EditPolicy");

                if (authorizationResult.Succeeded)
                {
                    await _profileService.UpdateUser(userId, profileResponceData);
                }
            }           
        }

        [Authorize]
        [HttpGet("DeleteUser/{userId}")]
        public async Task DeleteUser(string userId)
        {
            
            if (await _userManager.FindByIdAsync(userId) != null)
            {
                var authorizationResult = await _authorizationService.AuthorizeAsync(User, userId, "EditPolicy");

                if (authorizationResult.Succeeded)
                {
                    await _profileService.DeleteUser(userId);
                }

            }
   
        }
    }
}