using HelpMeApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System;
using System.Linq;
using HelpMeApp.Services.Models.Profile;

namespace HelpMeApp.WebAPI.Authorization
{
    public class UserValidAuthorizationHandler : AuthorizationHandler<CreatorRequirement, string>
    {
        private IProfileService _profileService;

        public UserValidAuthorizationHandler(IProfileService profileService)
        {
            _profileService = profileService;
        }

        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, CreatorRequirement requirement, string userProvidedId)
        {
            var userId = context.User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _profileService.GetUserByIdAsync(userProvidedId);

            if (userId == userProvidedId)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

        }
    }
}
