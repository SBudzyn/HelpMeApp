using HelpMeApp.Services.Models;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.Services.Models.Advert;
using HelpMeApp.Services.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Interfaces
{
    public interface IAdvertService
    {
        Task<IEnumerable<AdvertPreviewResponseData>> GetAdvertsByPageAsync(AdvertFiltersData filters, int page, int pageSize);
        Task<AdvertDetailedResponseData> GetAdvertByIdAsync(int id);
        Task<AdvertDetailedResponseData> AddAdvertAsync(AdvertPostData advert, Guid userId);
        Task<AdvertDetailedResponseData> UpdateAdvertAsync(AdvertPostData advert, int advertId);
        Task<AdvertDetailedResponseData> DeactivateAdvertAsync(int advertId);
        Task<GeneralData> GetGeneralDataAsync();
    }
}
