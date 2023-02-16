using Microsoft.AspNetCore.Authorization;
using System;

namespace HelpMeApp.WebAPI.Authorization
{
    public class CreatorRequirement : IAuthorizationRequirement
    {
        public Guid UserId { get; set; }

        public CreatorRequirement()
        {

        }

        public CreatorRequirement(Guid userId)
        {
            UserId = userId;
        }
    }
}
