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
        Task<ProfileResponseData> GetUserById(string userId);
        Task UpdateUser(string userId, ProfileResponseData profileResponseData);
        Task DeleteUser(string userId);
    }
}