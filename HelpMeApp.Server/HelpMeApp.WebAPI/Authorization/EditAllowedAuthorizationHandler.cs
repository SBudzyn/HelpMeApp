using HelpMeApp.Services.Interfaces;
using HelpMeApp.Services.Models.Advert;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMeApp.WebAPI.Authorization
{
    public class EditAllowedAuthorizationHandler : AuthorizationHandler<CreatorRequirement, int>
    {
        private IAdvertService _advertService;
        
        public EditAllowedAuthorizationHandler(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, CreatorRequirement requirement, int advertId)
        {
            var userId = Guid.Parse(context.User.Claims.First(c => c.Type == "UserId").Value);

            var advert = await _advertService.GetAdvertByIdAsync(advertId);

            if (advert.CreatorId == userId)
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

