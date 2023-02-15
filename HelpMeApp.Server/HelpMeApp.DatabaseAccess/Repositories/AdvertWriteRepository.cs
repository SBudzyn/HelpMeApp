using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Interfaces;
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
        private IAdvertReadRepository _advertReadRepository;

        public AdvertWriteRepository(HelpMeDbContext context, IAdvertReadRepository readRepository)
        {
            _context = context;
            _advertReadRepository = readRepository;
        }

        public async Task<Advert> AddAdvertAsync(Advert advert)
        {
            var domainAdvert = await _context.Adverts.AddAsync(advert);

            await _context.SaveChangesAsync();

            return await _advertReadRepository.GetAdvertByIdAsync(domainAdvert.Entity.Id);
        }

        public async Task<Advert> UpdateAdvertAsync(Advert advert)
        {
            _context.Entry(advert).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return await _advertReadRepository.GetAdvertByIdAsync(advert.Id);
        }

        public async Task<Advert> DeactivateAdvertAsync(int id)
        {
            var advert = await _advertReadRepository.GetAdvertByIdAsync(id);

            advert.IsClosed = true;

            await _context.SaveChangesAsync();

            return advert;
        }
    }
}
