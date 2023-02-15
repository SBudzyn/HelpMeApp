using HelpMeApp.DatabaseAccess.Entities.ReportEntity;
using HelpMeApp.DatabaseAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.DatabaseAccess.Repositories
{
    public class ReportReadRepository : IReportReadRepository
    {
        private HelpMeDbContext _context;

        public ReportReadRepository(HelpMeDbContext context)
        {
            _context = context;
        }

        public async Task<Report> GetReportByIdAsync(int id)
        {
            return await _context.Reports
                .Include(r => r.User)
                .Include(r => r.Advert)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
