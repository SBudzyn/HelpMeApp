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

        public UserController(IProfileService profileService, IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            _profileService = profileService;
        }

        private string GetUserFromClaims()
        {
            ClaimsPrincipal claimsPrincipal = HttpContext.User;
            var userId = claimsPrincipal.FindFirst(c => c.Type == "UserId").Value;
            return userId;
        }

        private async Task<bool> UserAutorization(string userId)
        {
            var authorizationResult = await _authorizationService.AuthorizeAsync(User, userId, "EditPolicy");

            if (authorizationResult.Succeeded)
            {
                return true;
            }            
            return false;
        }

        [HttpGet("get-user-by-id/{userId}")]
        public async Task<ActionResult<ProfileResponseData>> GetUserById(string userId)
        {
            var authorizationResult = UserAutorization(userId);
            if (authorizationResult.Result == true) 
            {
                return await _profileService.GetUserById(userId);
            }

            return BadRequest();
        }

        [Authorize]
        [HttpGet("get-my-info")]
        public async Task<ActionResult<ProfileResponseData>> GetMyInfo()
        {
            var userId = GetUserFromClaims();

            var authorizationResult = UserAutorization(userId);
            if (authorizationResult.Result == true)
            {
                var result = await _profileService.GetUserById(userId);
                return result;
            }

            return Unauthorized("You don`t have permission to modify the resource");
        }

        [Authorize]
        [HttpPut("update-user")]
        public async Task<ActionResult<ProfileResultMessageModel>> Update([FromBody] ProfileUpdateData profileResponseData)
        {
            var userId = GetUserFromClaims();

            var authorizationResult = UserAutorization(userId);
            if (authorizationResult.Result == true)
            {              
                 return await _profileService.UpdateUser(userId, profileResponseData);              
            }

            return Unauthorized("You don`t have permission to modify the resource");
        }

        [Authorize]
        [HttpGet("delete-user")]
        public async Task<ActionResult<ProfileResultMessageModel>> DeleteUser()
        {
            var userId = GetUserFromClaims();

            var authorizationResult = UserAutorization(userId);
            if (authorizationResult.Result == true)
            {
                return await _profileService.DeleteUser(userId);
            }

            return Unauthorized("You don`t have permission to modify the resource");
        }

        [Authorize]
        [HttpGet("get-adverts-user-need-help-by-page/{pageId}")]
        public async Task<ActionResult<IEnumerable<AdvertPreviewResponseData>>> GetAdvertsUserNeedHelpByPage(int pageId = 1, int pageSize = 20)
        {
            if (pageId < 1 || pageSize < 1)
            {
                return BadRequest();
            }

            var userId = GetUserFromClaims();

            var authorizationResult = UserAutorization(userId);
            if (authorizationResult.Result == true)
            {
                var result = await _profileService.GetAdvertsUserNeedHelpByPage(userId, pageId, pageSize);
                return result.ToList();
            }

            return Unauthorized("You don`t have permission to modify the resource");
        }

        [Authorize]
        [HttpGet("adverts-user-need-help-quantity")]
        public async Task<ActionResult<int>> AdvertsUserNeedHelpQuantity()
        {
            var userId = GetUserFromClaims();

            var authorizationResult = UserAutorization(userId);
            if (authorizationResult.Result == true)
            {
                var result = await _profileService.AdvertsUserNeedHelpQuantity(userId);
                return result;
            }

            return Unauthorized("You don`t have permission to modify the resource");
        }

        [Authorize]
        [HttpGet("adverts-user-can-help-quantity")]
        public async Task<ActionResult<int>> AdvertsUserCanHelpQuantity()
        {
            var userId = GetUserFromClaims();

            var authorizationResult = UserAutorization(userId);
            if (authorizationResult.Result == true)
            {
                var result = await _profileService.AdvertsUserCanHelpQuantity(userId);
                return result;
            }

            return Unauthorized("You don`t have permission to modify the resource");
        }
    }
}
