using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.DatabaseAccess.Interfaces
{
    public interface IAdvertWriteRepository
    {
        Task<Advert> AddAdvertAsync(Advert advert);
        Task<Advert> UpdateAdvertAsync(Advert advert);
        Task<Advert> DeactivateAdvertAsync(int id);
    }
}
