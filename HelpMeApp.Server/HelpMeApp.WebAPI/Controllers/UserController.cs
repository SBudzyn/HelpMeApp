using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HelpMeApp.Services.Models.Profile;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using HelpMeApp.Services.Interfaces;
using System.Security.Claims;
using System.Linq;
using HelpMeApp.Services.Models.Advert;

namespace HelpMeApp.WebAPI.Controllers
{
    [Route("api/profile")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IProfileService _profileService;
        private IAuthorizationService _authorizationService;
        private UserManager<AppUser> _userManager;

        public UserController(IProfileService profileService, IAuthorizationService authorizationService, UserManager<AppUser> userManager)
        {
            _userManager= userManager;
            _authorizationService = authorizationService;
            _profileService = profileService;
        }

        private string GetUserFromClaims()
        {
            ClaimsPrincipal claimsPrincipal = HttpContext.User;

            var userId = claimsPrincipal.FindFirst(c => c.Type == "UserId").Value;

            return userId;
        }

        [HttpGet("get-user-by-id/{userId}")]
        public async Task<ActionResult<ProfileResponseData>> GetUserById(string userId)
        {
            var userIdCheck = await _userManager.FindByIdAsync(userId);

            if ( userIdCheck != null)
            {
                return await _profileService.GetUserByIdAsync(userId);
            }

            return NotFound("User was not founded ");
        }

        [Authorize]
        [HttpGet("get-my-info")]
        public async Task<ActionResult<ProfileResponseData>> GetMyInfo()
        {
            var userId = GetUserFromClaims();

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, userId, "EditPolicy");

            if (authorizationResult.Succeeded)
            {
                var result = await _profileService.GetUserByIdAsync(userId);
                return result;
            }

            return Unauthorized("You don`t have permission to modify the resource");
        }

        [Authorize]
        [HttpPut("update-user")]
        public async Task<ActionResult<ProfileResultMessageModel>> Update([FromBody] ProfileUpdateData profileResponseData)
        {
            var userId = GetUserFromClaims();

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, userId, "EditPolicy");

            if (authorizationResult.Succeeded)
            {
                return await _profileService.UpdateUserAsync(userId, profileResponseData);
            }
            
            return Unauthorized("You don`t have permission to modify the resource");
        }

        [Authorize]
        [HttpGet("delete-user")]
        public async Task<ActionResult<ProfileResultMessageModel>> DeleteUser()
        {
            var userId = GetUserFromClaims();

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, userId, "EditPolicy");

            if (authorizationResult.Succeeded)
            {
                return await _profileService.DeleteUserAsync(userId);
            }

            return Unauthorized("You don`t have permission to modify the resource");
        }

        [HttpGet("get-user-needs-help-adverts-by-page/{pageId}/{userId}")]
        public async Task<ActionResult<IEnumerable<AdvertPreviewResponseData>>> GetUserNeedsHelpAdvertsByPage(string userId, int pageId = 1, int pageSize = 20)
        {
            if (pageId < 1 || pageSize < 1)
            {
                return BadRequest();
            }

            var userIdCheck = await _userManager.FindByIdAsync(userId);

            if (userIdCheck != null)
            {
                var result = await _profileService.GetUserNeedsHelpAdvertsByPageAsync(userId, pageId, pageSize);
                return result.ToList();
            }

            return BadRequest();
        }
    }
}
