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
        Task UpdateUser(string userId, ProfileResponceData profileResponceData);
        Task DeleteUser(string userId);
    }
}