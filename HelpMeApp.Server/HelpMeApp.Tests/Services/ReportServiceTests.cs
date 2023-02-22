using AutoMapper;
using HelpMeApp.DatabaseAccess.Interfaces;
using HelpMeApp.Services.Services;
using Moq;
using System;
using System.Threading.Tasks;
using HelpMeApp.DatabaseAccess.Entities.ReportEntity;
using HelpMeApp.Services.Models.Report;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace HelpMeApp.Tests.Services
{
    [TestFixture]
    public class ReportsServiceTests
    {
        private const string GetReportByAdvertAndUserAsyncMethodName = nameof(ReportService.GetReportByAdvertAndUserAsync);
        private const string AddReportAsyncMethodName = nameof(ReportService.AddReportAsync);

        private Mock<IReportReadRepository> _reportReadRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<IReportWriteRepository> _reportWriteRepositoryMock;

        private ReportService _reportService;

        [SetUp]
        public void TestInitialize()
        {
            _reportReadRepositoryMock = new Mock<IReportReadRepository>();
            _mapperMock = new Mock<IMapper>();
            _reportWriteRepositoryMock = new Mock<IReportWriteRepository>();

            _reportService = new ReportService
                (
                _reportWriteRepositoryMock.Object,
                _reportReadRepositoryMock.Object,
            _mapperMock.Object
            );
        }

        [TestCase(TestName = $"{GetReportByAdvertAndUserAsyncMethodName}. Should return a report on the user by providing his ID to ReportReadRepository ")]
        public async Task GetReportByAdvertAndUserAsyncMethodName_ReturnsReportData()
        {
            ReportData expected = new ReportData();

            Guid userId = new Guid();
            int advertId = 20;

            SetupGetReportByAdvertAndUserAsyncMock(advertId, userId);
            SetupReportMappingProfileToReportDataMock();

            var actual = await _reportService.GetReportByAdvertAndUserAsync(advertId, userId);
            Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        [TestCase(TestName = $"{AddReportAsyncMethodName}. Should create a new report, passing the content of the report, userId and advertId to the reportWriteService")]
        public async Task AddReportAsyncMethodName_ReturnsReportData()
        {
            ReportData expected = new ReportData();

            Report report = new Report();
            SetupReportMappingProfileToReportMock();
            SetupAddReportAsyncMock(report);

            var actual = await _reportService.AddReportAsync(new ReportData());

            Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        private void SetupGetReportByAdvertAndUserAsyncMock(int advertId, Guid userId)
        {
            _reportReadRepositoryMock
                .Setup(r => r.GetReportByAdvertAndUserAsync(advertId, userId))
                .ReturnsAsync(new Report());
        }

        private void SetupAddReportAsyncMock(Report report)
        {
            _reportWriteRepositoryMock
                .Setup(r => r.AddReportAsync(It.IsAny<Report>()))
                .ReturnsAsync(new Report());
        }

        private void SetupReportMappingProfileToReportDataMock()
        {
            _mapperMock
                .Setup(m => m.Map<ReportData>(It.IsAny<Report>()))
                .Returns(new ReportData());
        }

        private void SetupReportMappingProfileToReportMock()
        {
            _mapperMock
                .Setup(m => m.Map<Report>(It.IsAny<ReportData>()))
                .Returns(new Report());
            _mapperMock
                .Setup(m => m.Map<ReportData>(It.IsAny<Report>()))
                .Returns(new ReportData());
        }
    }
}
