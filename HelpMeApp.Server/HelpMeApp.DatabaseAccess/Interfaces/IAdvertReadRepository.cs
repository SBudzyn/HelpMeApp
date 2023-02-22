using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.DatabaseAccess.Interfaces
{
    public interface IAdvertReadRepository
    {
        Task<IEnumerable<Advert>> GetAdvertsByPageAsync(AdvertFilters filters, int page, int pageSize);
        Task<Advert> GetAdvertByIdAsync(int id);
        Task<Dictionary<int, string>> GetCategoriesAsync();
        Task<Dictionary<int, string>> GetTermsAsync();
        Task<Dictionary<int, string>> GetHelpTypesAsync();
        Task<int> CountAdvertsAsync();
        Task<IEnumerable<Advert>> GetUserNeedsHelpAdvertsByPageAsync(string userId, int page, int pageSize);
        Task<int> CountAdvertsUserCanHelpAsync(string userId);
    }
}
