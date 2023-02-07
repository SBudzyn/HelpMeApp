using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpMeApp.Services.Models.Profile;
using HelpMeApp.Services.DTO;

namespace HelpMeApp.Services.Interfaces
{
    public interface IProfileService
    {
        Task<ProfileResponseModel<ProfileRequestModel>> GetUserById(string userId);
        Task<ProfileResponseModel<ProfileEditionModel>> UpdateUser(string userId, ProfileEditionModel profileEditionModel);
        Task<ProfileResponseModel<ProfileEditionModel>> DeleteUser(string userId); 

    }
}
