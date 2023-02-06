using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.FiltersExtensionMethods;
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

        public async Task<IEnumerable<Advert>> GetAdvertsByPageAsync(int helpTypeId, int categoryId, string location, int termsId, string sortBy, int page, int pageSize)
        {
            return await _context.Adverts
                .Where(a => a.IsClosed == false)
                .FilterByHelpType(helpTypeId)
                .FilterByCategory(categoryId)
                .FilterByLocation(location)
                .FilterByTerms(termsId)
                .Include(a => a.Photos)
                .Sort(sortBy)
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
