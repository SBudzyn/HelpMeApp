using HelpMeApp.Services.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Interfaces
{
    public interface IProfileService
    {
       public Task<ProfileResponseModel<ProfileRequestModel>> GetUserById(string userId);
    }
}
