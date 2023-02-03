using AutoMapper;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Interfaces;
using HelpMeApp.Services.Interfaces;
using HelpMeApp.Services.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Services
{
    public class AdvertService : IAdvertService
    {
        private IAdvertReadRepository _advertReadRepository;
        private IAdvertWriteRepository _advertWriteRepository;
        private IMapper _mapper;

        public AdvertService(IAdvertReadRepository advertReadRepository, IAdvertWriteRepository advertWriteRepository, IMapper mapper)
        {
            _advertReadRepository = advertReadRepository;
            _advertWriteRepository = advertWriteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AdvertResponseData>> GetAdvertsByPage(int page, int pageSize)
        {
            var domainAdverts = await _advertReadRepository.GetAdvertsByPageAsync(page, pageSize);

            var advertsData = _mapper.Map<IEnumerable<AdvertResponseData>>(domainAdverts);

            return advertsData;
        }

        public async Task<AdvertResponseData> GetAdvertById(int id)
        {
            var domainAdvert = await _advertReadRepository.GetAdvertByIdAsync(id);

            var advertData = _mapper.Map<AdvertResponseData>(domainAdvert);

            return advertData;
        }

        public async Task<bool> AddAdvertAsync(AdvertPostData advert)
        {
            var domainAdvert = _mapper.Map<Advert>(advert);

            return await _advertWriteRepository.AddAdvertAsync(domainAdvert);
        }

        public async Task<bool> UpdateAdvertAsync(AdvertPostData advert)
        {
            var domainAdvert = _mapper.Map<Advert>(advert);

            return await _advertWriteRepository.UpdateAdvertAsync(domainAdvert);
        }

        public async Task<bool> DeactivateAdvert(int id)
        {
            return await _advertWriteRepository.DeactivateAdvert(id);
        }
    }
}
