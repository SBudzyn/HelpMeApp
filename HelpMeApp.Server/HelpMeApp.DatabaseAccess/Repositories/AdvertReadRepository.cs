using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Filters;
using HelpMeApp.DatabaseAccess.FiltersExtensionMethods;
using HelpMeApp.DatabaseAccess.Entities.CategoryEntity;
using HelpMeApp.DatabaseAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpMeApp.DatabaseAccess.Enums;

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
            return await _context.Adverts
                .Include(a => a.Category)
                .Include(a => a.Terms)
                .Include(a => a.Photos)
                .Include(a => a.Creator)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Dictionary<int, string>> GetCategoriesAsync()
        {
            return await _context.Categories.ToDictionaryAsync(c => c.Id, c => c.Name);
        }

        public async Task<Dictionary<int, string>> GetTermsAsync()
        {
            return await _context.Terms.ToDictionaryAsync(t => t.Id, t => t.Days);
        }

        public async Task<Dictionary<int, string>> GetHelpTypesAsync()
        {
            return await _context.HelpTypes.ToDictionaryAsync(h => h.Id, h => h.Name);
        }

        public async Task<int> CountAdvertsAsync()
        {
            return await _context.Adverts.CountAsync();
        }

        public async Task<IEnumerable<Advert>> GetUserNeedsHelpAdvertsByPageAsync(string userId, int page, int pageSize)
        {
            return await _context.Adverts
                .Where(a => a.IsClosed == false)
                .Where(a => a.CreatorId.ToString() == userId)
                .Where(a => a.HelpTypeId == (int)UserHelpType.NeedsHelp)
                .Include(a => a.Photos)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> CountAdvertsUserCanHelpAsync(string userId)
        {
            return await _context.Adverts
                .Where(a => a.HelpTypeId == (int)UserHelpType.CanHelp)
                .Where(a => a.CreatorId.ToString() == userId)
                .CountAsync();
        }

    }
}
