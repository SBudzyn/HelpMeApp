using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Interfaces;
using HelpMeApp.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.DatabaseAccess.Repositories
{
    public class AdvertWriteRepository : IAdvertWriteRepository
    {
        private HelpMeDbContext _context;

        public AdvertWriteRepository(HelpMeDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAdvertAsync(Advert advert)
        {
            await _context.Adverts.AddAsync(advert);

            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> UpdateAdvertAsync(Advert advert)
        {
            _context.Entry(advert).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> DeactivateAdvert(int id)
        {
            var advert = await _context.Adverts.FirstOrDefaultAsync(a => a.Id == id);

            if (advert == null)
            {
                return false;
            }

            advert.IsClosed = true;

            return await _context.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
