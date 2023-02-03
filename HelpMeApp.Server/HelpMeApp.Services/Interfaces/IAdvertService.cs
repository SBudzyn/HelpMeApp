using HelpMeApp.Services.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Interfaces
{
    public interface IAdvertService
    {
        Task<IEnumerable<AdvertResponseData>> GetAdvertsByPage(int page, int pageSize);
        Task<AdvertResponseData> GetAdvertById(int id);
        Task<AdvertResponseData> AddAdvertAsync(AdvertPostData advert);
        Task<bool> DeactivateAdvert(int id);
    }
}
