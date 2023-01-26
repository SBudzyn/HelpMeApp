using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpMeApp.Repositories.Entities.AdvertEntity;
using HelpMeApp.Repositories.Entities.ChatterEntity;
using HelpMeApp.Repositories.Entities.PhotoEntity;
using HelpMeApp.Repositories.Entities.ReportEntity;

namespace HelpMeApp.Repositories.Entities.UserEntity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int? Phone { get; set; }
        public string Email { get; set; } = null!;

        public int PhotoId { get; set; }
        public Photo Photo { get; set; } = null!;

        public DateTime RegistrationDate { get; set; }
        public string? Info { get; set; }
        public bool IsBlocked { get; set; }

        //public List<Advert> Adverts { get; set; } = new List<Advert>();
        //public List<Report> Reports { get; set; } = new List<Report>();
        public List<Chatter> Chatters { get; set; } = new List<Chatter>();
    }
}
