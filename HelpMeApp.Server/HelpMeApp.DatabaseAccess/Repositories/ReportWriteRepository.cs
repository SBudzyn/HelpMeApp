using HelpMeApp.DatabaseAccess.Entities.ReportEntity;
using HelpMeApp.DatabaseAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.DatabaseAccess.Repositories
{
    public class ReportWriteRepository : IReportWriteRepository
    {
        private HelpMeDbContext _context;
        private IReportReadRepository _reportReadRepository;

        public ReportWriteRepository(HelpMeDbContext context, IReportReadRepository reportReadRepository)
        {
            _context = context;
            _reportReadRepository = reportReadRepository;
        }

        public async Task<Report> AddReportAsync(Report report)
        {
            var domainAdvert = await _context.Reports.AddAsync(report);

            await _context.SaveChangesAsync();

            return await _reportReadRepository.GetReportByIdAsync(domainAdvert.Entity.Id);
        }
    }
}
