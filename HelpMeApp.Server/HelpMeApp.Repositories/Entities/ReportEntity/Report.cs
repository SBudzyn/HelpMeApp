﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Entities.UserEntity;

namespace HelpMeApp.DatabaseAccess.Entities.ReportEntity
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
