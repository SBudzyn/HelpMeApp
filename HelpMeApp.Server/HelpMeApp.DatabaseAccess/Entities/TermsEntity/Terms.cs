﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;

namespace HelpMeApp.DatabaseAccess.Entities.TermsEntity
{
    public class Terms
    {
        public int Id { get; set; }
        [Required]
        public string Days { get; set; }

        public List<Advert> Adverts { get; set; } = new List<Advert>();
    }
}