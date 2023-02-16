using HelpMeApp.Services.Models.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Interfaces
{
    public interface IReportService
    {
        Task<ReportData> GetReportByAdvertAndUserAsync(int advertId, Guid userId);
        Task<ReportData> AddReportAsync(ReportData report);
    }
}
