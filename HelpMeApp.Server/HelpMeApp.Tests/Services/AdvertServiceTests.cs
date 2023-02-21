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
    public class AdvertServiceTests
    {
        private const string GetAdvertsByPageAsyncMethodName = nameof(AdvertService.GetAdvertsByPageAsync);
        private const string GetAdvertByIdAsyncMethodName = nameof(AdvertService.GetAdvertByIdAsync);
        private const string AddAdvertAsyncMethodName = nameof(AdvertService.AddAdvertAsync);

        private Mock<IAdvertReadRepository> _advertReadRepositoryMock;
        private Mock<IAdvertWriteRepository> _advertWriteRepositoryMock;
        private Mock<IMapper> _mapperMock;

        private AdvertService _advertService;

        [SetUp]
        public void TestInitialize()
        {
            _advertReadRepositoryMock = new Mock<IAdvertReadRepository>();
            _advertWriteRepositoryMock = new Mock<IAdvertWriteRepository>();
            _mapperMock = new Mock<IMapper>();

            _advertService = new AdvertService
                (
                _advertReadRepositoryMock.Object, 
                _advertWriteRepositoryMock.Object, 
                _mapperMock.Object
                );
        }

        [TestCase(TestName = $"{GetAdvertsByPageAsyncMethodName}. Should return mapped collection of AdvertDetailedResponseData")]
        public async Task GetAdvertsByPageAsync_ReturnsAdvertPreviewResponseData()
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

        [TestCase(TestName = $"{GetAdvertByIdAsyncMethodName}. Should return AdvertDetailedResponseData mapped from Advert recieved from IAdvertRepository")]
        public async Task GetAdvertByIdAsync_ReturnsAdvertDetailedResponseData()
        {
            int advertId = 1;
            AdvertDetailedResponseData expected = new AdvertDetailedResponseData();

            SetupAdvertRepositoryGetAdvertByIdAsyncMock(advertId);
            SetupAdvertMappingProfileAdvertToAdvertDetailedResponseData();

            var actual = await _advertService.GetAdvertByIdAsync(advertId);

            Assert.AreEqual(expected.GetType(), actual.GetType()); 
        }

        [TestCase(TestName = $"{GetAdvertsByPageAsyncMethodName}. Should return AdvertDetailedResponseData mapped from Advert recieved from IAdvertRepository even if passed filters are null")]
        public async Task GetAdvertByIdAsync_ReturnsAdvertPreviewResponseData_WhenPassedFiltersAreNull()
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

        [TestCase(TestName = $"{AddAdvertAsyncMethodName}. Should return AdvertDetailedResponseData that is mapped from added Advert")]
        public async Task AddAdvertAsync_ReturnsAdvertDetailedResponseData()
        {
            var expected = new AdvertDetailedResponseData();

            SetupAdvertRepositoryAddAdvertAsyncMock();
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

        private void SetupAdvertRepositoryAddAdvertAsyncMock()
        {
            _advertWriteRepositoryMock
                .Setup(r => r.AddAdvertAsync(It.IsAny<Advert>()))
                .ReturnsAsync(new Advert());
        }

        private void SetupAdvertMappingProfileAdvertToAdvertDetailedResponseData()
        {
            _mapperMock
                .Setup(m => m.Map<AdvertDetailedResponseData>(It.IsAny<Advert>()))
                .Returns(new AdvertDetailedResponseData());

            _mapperMock
                .Setup(m => m.Map<IEnumerable<AdvertDetailedResponseData>>(It.IsAny<IEnumerable<Advert>>()))
                .Returns(new List<AdvertDetailedResponseData>());
        }

        private void SetupAdvertMappingProfileAdvertPostDataToAdvert()
        {
            _mapperMock
                .Setup(m => m.Map<Advert>(It.IsAny<AdvertPostData>()))
                .Returns(new Advert());
        }

        private IEnumerable<AdvertPreviewResponseData> CreateAdvertsPreviewResponseData()
        {
            return new List<AdvertPreviewResponseData>(); 
        }
    }
}
