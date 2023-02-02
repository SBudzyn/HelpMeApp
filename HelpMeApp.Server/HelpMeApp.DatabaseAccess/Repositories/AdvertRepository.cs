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
    public class AdvertRepository : IAdvertRepository
    {
        private HelpMeDbContext _context;
        public AdvertRepository(HelpMeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Advert>> GetAdvertsByPage(int page, int pageSize)
        {
            return await _context.Adverts
                .Where(a => a.IsClosed == false)
                .OrderBy(a => a.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Advert> GetAdvertById(int id)
        {
            return await _context.Adverts.FirstOrDefaultAsync(a => a.Id == id);
        }

    }
}
