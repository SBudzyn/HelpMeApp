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
using System.Security.Principal;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using HelpMeApp.Services.Models.Advert;

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
            _authorizationService = authorizationService;
            _userManager = userManager;
            _profileService = profileService;
        }

        [Authorize]
        [HttpGet("get-user-by-id/{userId}")]
        public async Task<ActionResult<ProfileResponseData>> GetUserById(string userId)
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
        [HttpGet("get-my-info")]
        public async Task<ActionResult<ProfileResponseData>> GetMyInfo()
        {
            ClaimsPrincipal claimsPrincipal = HttpContext.User;
            var userId = claimsPrincipal.FindFirst(c => c.Type == "UserId").Value;  
            
            var result = await _profileService.GetUserById(userId);

            return Ok(result);        
        }

        [Authorize]
        [HttpPut("update-user/{userId}")]
        public async Task<ActionResult<ProfileResultMessageModel>> Update(string userId, [FromBody] ProfileUpdateData profileResponseData)
        {

            var result = new ProfileResultMessageModel();

            if (await _userManager.FindByIdAsync(userId) != null)
            {
                var authorizationResult = await _authorizationService.AuthorizeAsync(User, userId, "EditPolicy");

                if (authorizationResult.Succeeded)
                {
                    result = await _profileService.UpdateUser(userId, profileResponseData);
                }
                return result;
            }

            return NotFound("User was not found");
        }

        [Authorize]
        [HttpGet("delete-user/{userId}")]
        public async Task<ActionResult<ProfileResultMessageModel>> DeleteUser(string userId)
        {
            var result = new ProfileResultMessageModel();

            if (await _userManager.FindByIdAsync(userId) != null)
            {
                var authorizationResult = await _authorizationService.AuthorizeAsync(User, userId, "EditPolicy");

                if (authorizationResult.Succeeded)
                {
                    result = await _profileService.DeleteUser(userId);
                    return result;
                }
                
            }

            return NotFound("User was not found");
        }

        [Authorize]
        [HttpGet("get-user-adverts/{userId}")]
        public async Task<ActionResult<IEnumerable<AdvertPreviewResponseData>>> GetAllUserAdverts(string userId)
        {
            if (await _userManager.FindByIdAsync(userId) != null)
            {
                var authorizationResult = await _authorizationService.AuthorizeAsync(User, userId, "EditPolicy");

                if (authorizationResult.Succeeded)
                {
                    var result = await _profileService.GetAllUserAdverts(userId);
                    return result.ToList();
                }

            }

            return NotFound("User was not found");
        }


    }
}
