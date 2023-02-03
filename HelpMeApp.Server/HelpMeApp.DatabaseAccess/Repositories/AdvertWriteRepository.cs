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

        public async Task<Advert> AddAdvertAsync(Advert advert)
        {
            var domainAdvert = await _context.Adverts.AddAsync(advert);

            await _context.SaveChangesAsync();

            return _context.Adverts.FirstOrDefault(a => a.Id == domainAdvert.Entity.Id);
        }

        public async Task<bool> DeactivateAdvertAsync(int id)
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
