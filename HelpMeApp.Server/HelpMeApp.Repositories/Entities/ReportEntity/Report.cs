using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpMeApp.Repositories.Entities.AdvertEntity;
using HelpMeApp.Repositories.Entities.UserEntity;

namespace HelpMeApp.Repositories.Entities.ReportEntity
{
    public class Report
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int AdvertId { get; set; }
        public Advert Advert { get; set; } = null!;

        public string? Text { get; set; }
    }
}
