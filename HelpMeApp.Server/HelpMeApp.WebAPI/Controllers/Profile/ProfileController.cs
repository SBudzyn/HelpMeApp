using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using HelpMeApp.Services.Models.Profile;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using System.Collections.Generic;
using HelpMeApp.Services.Interfaces.Profile;

namespace HelpMeApp.WebAPI.Controllers.Profile
{  
    [Route("api/profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private IProfileService _profileService;
        public ProfileController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IProfileService profileService)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._profileService = profileService;
        }

        [HttpGet("GetUserInfo/{id}")]
        public async Task<ActionResult<ProfileResponseModel<ProfileRequestModel>>> GetUserInfo(string id) {
            var result = await _profileService.GetUserById(id);          
            return result;

        }
       /* public UserManager<AppUser> GetUserById()
        {
            return;
        }  */
       
    }
}
