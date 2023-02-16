using HelpMeApp.DatabaseAccess.Entities.ReportEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.DatabaseAccess.Interfaces
{
    public interface IReportReadRepository
    {
        Task<Report> GetReportByIdAsync(int id);
        Task<Report> GetReportByAdvertAndUserAsync(int advertId, Guid userId);
    }
}
