using AutoMapper;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Filters;
using HelpMeApp.DatabaseAccess.Interfaces;
using HelpMeApp.Services.Interfaces;
using HelpMeApp.Services.Models;
using HelpMeApp.Services.Models.Advert;
using HelpMeApp.Services.Models.Filters;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IEnumerable<AdvertPreviewResponseData>> GetAdvertsByPage([FromQuery] AdvertFiltersData filters, int page, int pageSize)
        {
            var filtersDomain = _mapper.Map<AdvertFilters>(filters);

            var domainAdverts = await _advertReadRepository.GetAdvertsByPageAsync(filtersDomain, page, pageSize);

            var advertsData = _mapper.Map<IEnumerable<AdvertPreviewResponseData>>(domainAdverts);

            return advertsData;
        }

        public async Task<AdvertDetailedResponseData> GetAdvertById(int id)
        {
            var domainAdvert = await _advertReadRepository.GetAdvertByIdAsync(id);

            var advertData = _mapper.Map<AdvertDetailedResponseData>(domainAdvert);

            return advertData;
        }

        public async Task<AdvertDetailedResponseData> AddAdvertAsync(AdvertPostData advert, Guid userId)
        {
            var mappedAdvert = _mapper.Map<Advert>(advert);
            mappedAdvert.CreatorId = userId;

            var domainAdvert = await _advertWriteRepository.AddAdvertAsync(mappedAdvert);

            return _mapper.Map<AdvertDetailedResponseData>(domainAdvert);
        }

        public async Task<AdvertDetailedResponseData> UpdateAdvertAsync(AdvertPostData advertUpdate, int advertId)
        {
            var domainAdvert = await _advertReadRepository.GetAdvertByIdAsync(advertId);

            var mappedAdvertUpdate = _mapper.Map(advertUpdate, domainAdvert);

            var updatedDomainAdvert = await _advertWriteRepository.UpdateAdvertAsync(mappedAdvertUpdate);

            return _mapper.Map<AdvertDetailedResponseData>(updatedDomainAdvert);
        }

        public async Task<AdvertDetailedResponseData> DeactivateAdvertAsync(int advertId)
        {
            var deactivatedAdvert = await _advertWriteRepository.DeactivateAdvertAsync(advertId);

            return _mapper.Map<AdvertDetailedResponseData>(deactivatedAdvert);
        }

        public async Task<GeneralData> GetGeneralDataAsync()
        {
            var categories = await _advertReadRepository.GetCategoriesAsync();

            var terms = await _advertReadRepository.GetTermsAsync();

            var advertsQuantity = await _advertReadRepository.CountAdverts();

            return new GeneralData { Categories = categories, Terms = terms, AdvertsQuantity = advertsQuantity };
        }

        public async Task<IEnumerable<AdvertPreviewResponseData>> GetAllUserAdverts(string userId)
        {
            var usersAdverts = await _advertReadRepository.GetAllUserAdverts(userId);

            var advertsData = _mapper.Map<IEnumerable<AdvertPreviewResponseData>>(usersAdverts);

            return advertsData;
        } 

    }
}
