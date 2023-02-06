using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.DatabaseAccess.Interfaces
{
    public interface IAdvertReadRepository
    {
        Task<IEnumerable<Advert>> GetAdvertsByPageAsync(string category, string location, string terms, string helpType, int page, int pageSize);
        Task<Advert> GetAdvertByIdAsync(int id);
    }
}
