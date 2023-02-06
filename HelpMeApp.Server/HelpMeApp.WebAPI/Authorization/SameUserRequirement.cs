using Microsoft.AspNetCore.Authorization;
using System;

namespace HelpMeApp.WebAPI.Authorization
{
    public class SameUserRequirement : IAuthorizationRequirement
    {
        public Guid UserId { get; set; }

        public SameUserRequirement()
        {

        }

        public SameUserRequirement(Guid userId)
        {
            UserId = userId;
        }
    }
}
