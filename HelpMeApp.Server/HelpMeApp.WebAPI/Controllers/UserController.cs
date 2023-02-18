﻿using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;
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

        private string GetUserFromClaims()
        {
            ClaimsPrincipal claimsPrincipal = HttpContext.User;
            var userId = claimsPrincipal.FindFirst(c => c.Type == "UserId").Value;
            return userId;
        }

        private async Task<bool> UserAutorization(string userId)
        {
            if (await _userManager.FindByIdAsync(userId) != null)
            {
                var authorizationResult = await _authorizationService.AuthorizeAsync(User, userId, "EditPolicy");

                if (authorizationResult.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }

        [Authorize]
        [HttpGet("get-user-by-id/{userId}")]
        public async Task<ActionResult<ProfileResponseData>> GetUserById(string userId)
        {
            var authorizationResult = UserAutorization(userId);
            if (authorizationResult.Result == true) 
            {
                return await _profileService.GetUserById(userId);
            }

            return Unauthorized("You don`t have permission to modify the resource");
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

            return NotFound("User was not found");
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

            return NotFound("User was not found");
        }

        [Authorize]
        [HttpGet("get-user-adverts/{pageId}")]
        public async Task<ActionResult<IEnumerable<AdvertPreviewResponseData>>> GetAllUserAdverts(int pageId = 1, int pageSize = 2)
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

            return NotFound("User was not found");
        }

        [Authorize]
        [HttpGet("count-how-much-user-helps")]
        public async Task<ActionResult<int>> CountHowMuchUserHelps()
        {
            var userId = GetUserFromClaims();

            var authorizationResult = UserAutorization(userId);
            if (authorizationResult.Result == true)
            {
                var result = await _profileService.CountHowMuchUserHelps(userId);
                return result;
            }

            return NotFound("User was not found");
        }
    }
}
