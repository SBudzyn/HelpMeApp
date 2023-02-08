using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Entities.CategoryEntity;
using HelpMeApp.DatabaseAccess.Interfaces;
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

        public async Task<IEnumerable<Advert>> GetAdvertsByPageAsync(int page, int pageSize)
        {
            return await _context.Adverts
                .Where(a => a.IsClosed == false)
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

        public async Task<Dictionary<int, string>> GetCategoriesAsync()
        {
            return await _context.Categories.ToDictionaryAsync(c => c.Id, c => c.Name);
        }

        public async Task<Dictionary<int, string>> GetTermsAsync()
        {
            return await _context.Terms.ToDictionaryAsync(t => t.Id, t => t.Days);
        }

        public async Task<int> CountAdverts()
        {
            return await _context.Adverts.CountAsync();
        }
    }
}
