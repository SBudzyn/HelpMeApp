using AutoMapper;
using HelpMeApp.DatabaseAccess.Entities.ReportEntity;
using HelpMeApp.DatabaseAccess.Interfaces;
using HelpMeApp.Services.Interfaces;
using HelpMeApp.Services.Models.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Services
{
    public class ReportService : IReportService
    {
        private IReportReadRepository _reportReadRepository;
        private IReportWriteRepository _reportWriteRepository;
        private IMapper _mapper;

        public ReportService(IReportWriteRepository reportWriteRepository, IReportReadRepository reportReadRepository, IMapper mapper)
        {
            _reportReadRepository = reportReadRepository;
            _reportWriteRepository = reportWriteRepository;
            _mapper = mapper;
        }

        public async Task<ReportData> GetReportByAdvertAndUserAsync(int advertId, Guid userId)
        {
            var domainReport = await _reportReadRepository.GetReportByAdvertAndUserAsync(advertId, userId);

            return _mapper.Map<ReportData>(domainReport);
        }

        public async Task<ReportData> AddReportAsync(ReportData report)
        {
            var mappedReport = _mapper.Map<Report>(report);

            var domainReport = await _reportWriteRepository.AddReportAsync(mappedReport);

            return _mapper.Map<ReportData>(domainReport);
        }
    }
}
