using HelpMeApp.Services.Models.Advert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Interfaces
{
    public interface IAdvertService
    {
        Task<IEnumerable<AdvertPreviewResponseData>> GetAdvertsByPage(string category, string location, string terms, string helpType, int page, int pageSize);
        Task<AdvertDetailedResponseData> GetAdvertById(int id);
        Task<AdvertDetailedResponseData> AddAdvertAsync(AdvertPostData advert, Guid userId);
        Task<AdvertDetailedResponseData> UpdateAdvertAsync(AdvertPostData advert, int advertId);
        Task<AdvertDetailedResponseData> DeactivateAdvertAsync(int advertId);
    }
}
