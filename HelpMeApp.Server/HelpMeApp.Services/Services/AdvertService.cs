using AutoMapper;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Interfaces;
using HelpMeApp.Services.Interfaces;
using HelpMeApp.Services.Models.Advert;
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

        public async Task<IEnumerable<AdvertBoardResponseData>> GetAdvertsByPage(int page, int pageSize)
        {
            var domainAdverts = await _advertReadRepository.GetAdvertsByPageAsync(page, pageSize);

            var advertsData = _mapper.Map<IEnumerable<AdvertBoardResponseData>>(domainAdverts);

            return advertsData;
        }

        public async Task<AdvertFullResponseData> GetAdvertById(int id)
        {
            var domainAdvert = await _advertReadRepository.GetAdvertByIdAsync(id);

            var advertData = _mapper.Map<AdvertFullResponseData>(domainAdvert);

            return advertData;
        }

        public async Task<AdvertFullResponseData> AddAdvertAsync(AdvertPostData advert)
        {
            var mappedAdvert = _mapper.Map<Advert>(advert);

            var domainAdvert = await _advertWriteRepository.AddAdvertAsync(mappedAdvert);

            return _mapper.Map<AdvertFullResponseData>(domainAdvert);
        }

        public async Task<bool> DeactivateAdvertAsync(int id)
        {
            return await _advertWriteRepository.DeactivateAdvertAsync(id);
        }
    }
}
