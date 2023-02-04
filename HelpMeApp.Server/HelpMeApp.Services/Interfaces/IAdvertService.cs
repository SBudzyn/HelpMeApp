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
        Task<IEnumerable<AdvertBoardResponseData>> GetAdvertsByPage(int page, int pageSize);
        Task<AdvertFullResponseData> GetAdvertById(int id);
        Task<AdvertFullResponseData> AddAdvertAsync(AdvertPostData advert);
        Task<bool> DeactivateAdvertAsync(int id);
    }
}
