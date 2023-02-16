using AutoMapper;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Filters;
using HelpMeApp.DatabaseAccess.Interfaces;
using HelpMeApp.Services.Models.Advert;
using HelpMeApp.Services.Models.Filters;
using HelpMeApp.Services.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Tests.Services
{
    [TestFixture]
    public class AdvertServiceTest
    {
        private Mock<IAdvertReadRepository> _advertReadRepositoryMock;
        private Mock<IAdvertWriteRepository> _advertWriteRepository;
        private Mock<IMapper> _mapper;

        private AdvertService _advertService;

        [SetUp]
        public void TestInitialize()
        {
            _advertReadRepositoryMock = new Mock<IAdvertReadRepository>();
            _advertWriteRepository = new Mock<IAdvertWriteRepository>();
            _mapper = new Mock<IMapper>();

            _advertService = new AdvertService(_advertReadRepositoryMock.Object, _advertWriteRepository.Object, _mapper.Object);
        }

        [TestCase(TestName = $"{nameof(AdvertService.GetAdvertsByPageAsync)}. Should return mapped collection of AdvertDetailedResponseData")]
        public async Task GetAdvertsByPageAsyncTest()
        {
            IEnumerable<AdvertPreviewResponseData> expected = CreateAdvertsPreviewResponseData();
            
            AdvertFilters advertFilters = new AdvertFilters();
            int page = 1;
            int pageSize = 20;

            SetupAdvertRepositoryGetByPageAsyncMock(advertFilters, page, pageSize);
            SetupAdvertMappingProfileAdvertToAdvertDetailedResponseData();

            var actual = await _advertService.GetAdvertsByPageAsync(new AdvertFiltersData(), page, pageSize);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = $"{nameof(AdvertService.GetAdvertByIdAsync)}. Should return AdvertDetailedResponseData mapped from Advert recieved from IAdvertRepository")]
        public async Task GetAdvertByIdAsyncTest()
        {
            int advertId = 1;
            AdvertDetailedResponseData expected = new AdvertDetailedResponseData();

            SetupAdvertRepositoryGetAdvertByIdAsyncMock(advertId);
            SetupAdvertMappingProfileAdvertToAdvertDetailedResponseData();

            var actual = await _advertService.GetAdvertByIdAsync(advertId);

            Assert.AreEqual(expected.GetType(), actual.GetType()); 
        }

        [TestCase(TestName = $"{nameof(AdvertService.GetAdvertsByPageAsync)}. Should return AdvertDetailedResponseData mapped from Advert recieved from IAdvertRepository even if passed filters are null")]
        public async Task GetAdvertByIdAsyncNullForFiltersDataTest()
        {
            IEnumerable<AdvertPreviewResponseData> expected = CreateAdvertsPreviewResponseData();

            AdvertFilters advertFilters = null;
            int page = 1;
            int pageSize = 20;

            SetupAdvertRepositoryGetByPageAsyncMock(advertFilters, page, pageSize);
            SetupAdvertMappingProfileAdvertToAdvertDetailedResponseData();

            var actual = await _advertService.GetAdvertsByPageAsync(new AdvertFiltersData(), page, pageSize);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = $"{nameof(AdvertService.AddAdvertAsync)}. Should return AdvertDetailedResponseData that is mapped from added Advert")]
        public async Task AddAdvertAsyncTest()
        {
            var expected = new AdvertDetailedResponseData();

            SetupAdvertRepositoryAddAdvertAsyncMock(new Advert());
            SetupAdvertMappingProfileAdvertPostDataToAdvert();
            SetupAdvertMappingProfileAdvertToAdvertDetailedResponseData();

            var actual = await _advertService.AddAdvertAsync(new AdvertPostData(), new Guid());

            Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        private void SetupAdvertRepositoryGetByPageAsyncMock(AdvertFilters advertFilters, int page, int pageSize)
        {
            _advertReadRepositoryMock
                .Setup(r => r.GetAdvertsByPageAsync(advertFilters, page, pageSize))
                .ReturnsAsync(new List<Advert>());
        }

        private void SetupAdvertRepositoryGetAdvertByIdAsyncMock(int id)
        {
            _advertReadRepositoryMock
                .Setup(r => r.GetAdvertByIdAsync(id))
                .ReturnsAsync(new Advert());
        }

        private void SetupAdvertRepositoryAddAdvertAsyncMock(Advert advert)
        {
            _advertWriteRepository
                .Setup(r => r.AddAdvertAsync(advert))
                .ReturnsAsync(new Advert());
        }

        private void SetupAdvertMappingProfileAdvertToAdvertDetailedResponseData()
        {
            _mapper
                .Setup(m => m.Map<AdvertDetailedResponseData>(It.IsAny<Advert>()))
                .Returns(new AdvertDetailedResponseData());

            _mapper
                .Setup(m => m.Map<IEnumerable<AdvertDetailedResponseData>>(It.IsAny<IEnumerable<Advert>>()))
                .Returns(new List<AdvertDetailedResponseData>());
        }

        private void SetupAdvertMappingProfileAdvertPostDataToAdvert()
        {
            _mapper
                .Setup(m => m.Map<Advert>(It.IsAny<AdvertPostData>()))
                .Returns(new Advert());
        }

        private IEnumerable<AdvertPreviewResponseData> CreateAdvertsPreviewResponseData()
        {
            return new List<AdvertPreviewResponseData>(); 
        }
    }
}
