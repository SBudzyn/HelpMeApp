using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Services.Models.Report
{
    public class ReportData
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int AdvertId { get; set; }
        public string AdvertTitle { get; set; }
        public string Text { get; set; }
        public bool IsResolved { get; set; }
    }
}
