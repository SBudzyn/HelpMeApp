﻿using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;

namespace HelpMeApp.DatabaseAccess.Entities.ReportEntity
{
    public class Report
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }
        public AppUser User { get; set; } = null!;

        public int AdvertId { get; set; }
        public Advert Advert { get; set; } = null!;

        public string Text { get; set; }
    }
}
