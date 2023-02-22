using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpMeApp.Services.Models.Advert;
using HelpMeApp.Services.Models.Profile;

namespace HelpMeApp.Services.Interfaces
{
    public interface IProfileService
    {
        Task<ProfileResponseData> GetUserByIdAsync(string userId);
        Task<ProfileResultMessageModel> UpdateUserAsync(string userId, ProfileUpdateData profileUpdateData);
        Task<ProfileResultMessageModel> DeleteUserAsync(string userId);
        Task<IEnumerable<AdvertPreviewResponseData>> GetUserNeedsHelpAdvertsByPageAsync(string userId, int page, int pageSize);
    }
}
