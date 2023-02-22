using AutoMapper;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Entities.PhotoEntity;
using HelpMeApp.DatabaseAccess.Filters;
using HelpMeApp.DatabaseAccess.Interfaces;
using HelpMeApp.Services.Helpers;
using HelpMeApp.Services.Interfaces;
using HelpMeApp.Services.Models;
using HelpMeApp.Services.Models.Advert;
using HelpMeApp.Services.Models.Chat;
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

        public async Task<IEnumerable<AdvertPreviewResponseData>> GetAdvertsByPageAsync(AdvertFiltersData filters, int page, int pageSize)
        {
            var filtersDomain = _mapper.Map<AdvertFilters>(filters);

            var domainAdverts = await _advertReadRepository.GetAdvertsByPageAsync(filtersDomain, page, pageSize);
            var mappedAdverts = new List<AdvertPreviewResponseData>();

            foreach (var advert in domainAdverts)
            {
                var advertData = _mapper.Map<AdvertPreviewResponseData>(advert);

                advertData.Photo = ImageConvertorHelper.ConvertPhotoToString(advert.Photos.FirstOrDefault());

                mappedAdverts.Add(advertData);
            }

            return mappedAdverts;
        }

        public async Task<AdvertDetailedResponseData> GetAdvertByIdAsync(int id)
        {
            var domainAdvert = await _advertReadRepository.GetAdvertByIdAsync(id);

            var advertData = _mapper.Map<AdvertDetailedResponseData>(domainAdvert);

            advertData.CreatorPhoto = ImageConvertorHelper.ConvertPhotoToString(domainAdvert.Creator?.PhotoPrefix, domainAdvert.Creator?.Photo);
            advertData.Photos = domainAdvert.Photos.Select(x => ImageConvertorHelper.ConvertPhotoToString(x)).ToList();

            return advertData;
        }

        public async Task<AdvertDetailedResponseData> AddAdvertAsync(AdvertPostData advert, Guid userId)
        {
            var mappedAdvert = _mapper.Map<Advert>(advert);
            mappedAdvert.CreatorId = userId;
            mappedAdvert.Photos = advert.Photos.Select(x => 
                                  new Photo { Data = ImageConvertorHelper.ConvertToBase64(x),
                                              Prefix = ImageConvertorHelper.GetImagePrefix(x) }).ToList();

            var domainAdvert = await _advertWriteRepository.AddAdvertAsync(mappedAdvert);

            var response = _mapper.Map<AdvertDetailedResponseData>(domainAdvert);

            response.CreatorPhoto = ImageConvertorHelper.ConvertPhotoToString(domainAdvert.Creator?.PhotoPrefix, domainAdvert.Creator?.Photo);
            response.Photos = domainAdvert.Photos.Select(x => ImageConvertorHelper.ConvertPhotoToString(x)).ToList();

            return response;
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

            var helpTypes = await _advertReadRepository.GetHelpTypesAsync();

            var advertsQuantity = await _advertReadRepository.CountAdvertsAsync();

            return new GeneralData { Categories = categories, Terms = terms, HelpTypes = helpTypes, AdvertsQuantity = advertsQuantity };
        }
    }
}
