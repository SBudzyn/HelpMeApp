using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Filters;
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

        public async Task<IEnumerable<Advert>> GetAdvertsByPageAsync(AdvertFilters filters, int page, int pageSize)
        {
            return await _context.Adverts
                .Where(a => a.IsClosed == false)
                .FilterByHelpType(filters.HelpTypeId)
                .FilterByCategory(filters.CategoryId)
                .FilterByLocation(filters.Location)
                .FilterByTerms(filters.TermsId)
                .Include(a => a.Photos)
                .Sort(filters.SortBy)
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
