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
        Task<ProfileResponceData> GetUserById(string userId);
        Task<ProfileResultMessageModel> UpdateUser(string userId, ProfileUpdateData profileUpdateData);
        Task<ProfileResultMessageModel> DeleteUser(string userId);
    }
}