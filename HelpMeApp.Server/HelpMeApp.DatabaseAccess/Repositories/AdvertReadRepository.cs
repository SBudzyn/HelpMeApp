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
    public class AdvertReadRepository : IAdvertReadRepository
    {
        private HelpMeDbContext _context;

        public AdvertReadRepository(HelpMeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Advert>> GetAdvertsByPageAsync(string category, string location, string terms, string helpType, int page, int pageSize)
        {
            return await _context.Adverts
                .Where(a => a.IsClosed == false)
                .Where(a => helpType == null || a.HelpType.Name.ToLower() == helpType.ToLower())
                .Where(a => category == null || a.Category.Name.ToLower() == category.ToLower())
                .Where(a => location == null || a.Location.ToLower() == location.ToLower())
                //.Where(a => a.Terms.Days.ToString() == terms.ToLower() || terms == null)
                .Include(a => a.Photos)
                .OrderBy(a => a.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Advert> GetAdvertByIdAsync(int id)
        {
            return await _context.Adverts.FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
