using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.DatabaseAccess.Interfaces
{
    public interface IAdvertRepository
    {
        Task<IEnumerable<Advert>> GetAdvertsByPage(int page, int pageSize);
        Task<Advert> GetAdvertById(int id);
    }
}
