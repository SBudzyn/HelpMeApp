using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpMeApp.Services.Models.Profile;

namespace HelpMeApp.Services.Interfaces
{
    public interface IProfileService
    {
        Task<ProfileResultMessagesData<ProfileResponceData>> GetUserById(string userId);
        Task<ProfileResultMessagesData<ProfileEditionModel>> UpdateUser(string userId, ProfileEditionModel profileEditionModel);
        Task<ProfileResultMessagesData<ProfileEditionModel>> DeleteUser(string userId);
    }
}