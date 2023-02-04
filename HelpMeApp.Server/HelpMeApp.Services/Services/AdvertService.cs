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

        public async Task<AdvertFullResponseData> AddAdvertAsync(AdvertPostData advert, Guid userId)
        {
            var mappedAdvert = _mapper.Map<Advert>(advert);
            mappedAdvert.CreatorId = userId;

            var domainAdvert = await _advertWriteRepository.AddAdvertAsync(mappedAdvert);

            return _mapper.Map<AdvertFullResponseData>(domainAdvert);
        }

        public async Task<AdvertFullResponseData> DeactivateAdvertAsync(int advertId, Guid userId)
        {
            var domainAdvert = await _advertReadRepository.GetAdvertByIdAsync(advertId);

            if (domainAdvert == null)
            {
                throw new KeyNotFoundException("The requested advert doesn`t exist");
            }

            if (domainAdvert.CreatorId != userId)
            {
                throw new UnauthorizedAccessException("You don`t have permission to delete this advert");
            }

            var deactivatedAdvert = await _advertWriteRepository.DeactivateAdvertAsync(advertId);

            return _mapper.Map<AdvertFullResponseData>(deactivatedAdvert);
        }
    }
}
