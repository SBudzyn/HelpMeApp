using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;
using HelpMeApp.DatabaseAccess.Entities.CategoryEntity;
using HelpMeApp.DatabaseAccess.Entities.ChatEntity;
using HelpMeApp.DatabaseAccess.Entities.HelpTypeEntity;
using HelpMeApp.DatabaseAccess.Entities.MessageEntity;
using HelpMeApp.DatabaseAccess.Entities.PhotoEntity;
using HelpMeApp.DatabaseAccess.Entities.ReportEntity;
using HelpMeApp.DatabaseAccess.Entities.SenderRoleEntity;
using HelpMeApp.DatabaseAccess.Entities.TermsEntity;
using Microsoft.AspNetCore.Identity;

namespace HelpMeApp.DatabaseAccess.Seeders
{
    public static class DatabaseSeeder
    {
        public static List<Advert> Adverts = new List<Advert>();
        public static List<AppUser> AppUsers = new List<AppUser>();
        public static List<Chat> Chats = new List<Chat>();
        public static List<Message> Messages = new List<Message>();
        //public static List<Photo> Photos = new List<Photo>();
        public static List<Report> Reports = new List<Report>();

        public static bool IsCalled = false;

        public static List<IdentityRole<Guid>> IdentityRoles = new List<IdentityRole<Guid>>()
        {
            new IdentityRole<Guid>() {Id = new Guid("00000000-0000-0000-0000-000000000001"), Name = "User", NormalizedName = "User" }
        };

        public static List<IdentityUserRole<Guid>> IdentityUserRoles = new List<IdentityUserRole<Guid>>();

        public static List<Category> Categories = new List<Category>()
        {
            new Category(){ Id = 1, Name = "Food" },
            new Category(){ Id = 2, Name = "Clothes" },
            new Category(){ Id = 3, Name = "Evacuation" },
            new Category(){ Id = 4, Name = "Repairs" }
        };

        public static List<HelpType> HelpTypes = new List<HelpType>()
        {
            new HelpType(){ Id = 1, Name = "NeedHelp" },
            new HelpType(){ Id = 2, Name = "CanHelp" }
        };

        public static List<SenderRole> SenderRoles = new List<SenderRole>()
        {
            new SenderRole(){ Id = 1, Name = "Creator" },
            new SenderRole(){ Id = 2, Name = "Responder" },
            new SenderRole(){ Id = 3, Name = "System" }
        };

        public static List<Terms> Terms = new List<Terms>()
        {
            new Terms(){ Id = 1, Days = "1" },
            new Terms(){ Id = 2, Days = "2-3" },
            new Terms(){ Id = 3, Days = "5-7" },
            new Terms(){ Id = 4, Days = "10-20" },
            new Terms(){ Id = 5, Days = "21-30" },
        };

        public static void Init()
        {
            Randomizer.Seed = new Random(10000);

            var reportId = 1;
            var reportFaker = new Faker<Report>("uk")
                .RuleFor(r => r.Id, _ => reportId++)
                .RuleFor(r => r.Text, f => f.Lorem.Sentences(f.Random.Number(1, 5)));

            var messageId = 1;
            var messageFaker = new Faker<Message>("uk")
                .RuleFor(m => m.Id, _ => messageId++)
                .RuleFor(m => m.SenderRoleId, f => f.PickRandom(SenderRoles).Id)
                .RuleFor(m => m.Text, f => f.Lorem.Sentences(f.Random.Number(1, 5)))
                .RuleFor(m => m.CreationDate, f => f.Date.Recent());

            var chatId = 1;
            var chatFaker = new Faker<Chat>("uk")
                .RuleFor(c => c.Id, _ => chatId++)
                .RuleFor(c => c.IsConfirmedBySecondSide, f => f.PickRandom(true, false))
                .RuleFor(c => c.IsConfirmedByCreator, f => f.PickRandom(true, false))
                .RuleFor(c => c.Messages, (f, c) =>
                {
                    messageFaker.RuleFor(m => m.ChatId, _ = c.Id);

                    var messages = messageFaker.GenerateBetween(1, 9);

                    Messages.AddRange(messages);

                    return null;
                });

            var advertId = 1;
            var advertFaker = new Faker<Advert>("uk")
               .RuleFor(a => a.Id, _ => advertId++)
               .RuleFor(a => a.Header, f => f.Hacker.Phrase())
               .RuleFor(a => a.Info, f => f.Hacker.Phrase())
               .RuleFor(a => a.Location, f => f.Address.City())
               .RuleFor(a => a.HelpTypeId, f => f.PickRandom(HelpTypes).Id)
               .RuleFor(a => a.CategoryId, f => f.PickRandom(Categories).Id)
               .RuleFor(a => a.TermsId, f => f.PickRandom(Terms).Id)
               .RuleFor(a => a.CreationDate, f => f.Date.Between(new DateTime(2023, 01, 01), new DateTime(2023, 01, 25)))
               .RuleFor(a => a.ClosureDate, f => f.PickRandom(default, f.Date.Between(new DateTime(2023, 01, 26), new DateTime(2023, 02, 10))))
               .RuleFor(a => a.IsClosed, f => f.PickRandom(true, false));

            var hasher = new PasswordHasher<AppUser>();
            var appUserFaker = new Faker<AppUser>("uk")
               .RuleFor(u => u.Id, f => f.Random.Guid())
               .RuleFor(u => u.Name, f => f.Name.FirstName())
               .RuleFor(u => u.Surname, f => f.Name.LastName())
               .RuleFor(u => u.RegistrationDate, f => f.Date.Past())
               .RuleFor(u => u.Info, f => f.Hacker.Phrase())
               .RuleFor(u => u.IsBlocked, f => f.PickRandom(true, false))
               .RuleFor(u => u.UserName, (f, p) => f.Internet.UserName(p.Name, p.Surname))
               .RuleFor(u => u.Email, (f, p) => f.Internet.Email(p.Name, p.UserName))
               .RuleFor(u => u.PasswordHash, f => hasher.HashPassword(null, "admin"))
               .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber())
               .RuleFor(u => u.Adverts, (f, u) =>
               {
                   advertFaker.RuleFor(a => a.CreatorId, _ => u.Id);

                   var adverts = advertFaker.GenerateBetween(1, 4);

                   Adverts.AddRange(adverts);

                   return null;
               })
               .RuleFor(u => u.Reports, (f, u) =>
               {
                   reportFaker.RuleFor(r => r.UserId, _ => u.Id);
                   reportFaker.RuleFor(r => r.AdvertId, f =>
                   {
                       var adverts = Adverts.Where(x => x.CreatorId != u.Id).ToList();
                       if (adverts.Any()) return f.PickRandom(adverts).Id;
                       return 5;
                   });

                   var reports = reportFaker.GenerateBetween(1, 2);
                   Reports.AddRange(reports);

                   return null;
               })
               .RuleFor(u => u.Chats, (f, u) =>
               {
                   chatFaker.RuleFor(c => c.UserId, _ => u.Id);
                   chatFaker.RuleFor(r => r.AdvertId, f =>
                   {
                       var adverts = Adverts.Where(x => x.CreatorId != u.Id).ToList();
                       if (adverts.Any()) return f.PickRandom(adverts).Id;
                       return 5;
                   });

                   var chats = chatFaker.GenerateBetween(1, 3);
                   Chats.AddRange(chats);

                   return null;
               });

            var users = appUserFaker.Generate(9);
            AppUsers.AddRange(users);

            var userRoles = new List<IdentityUserRole<Guid>>();
            foreach (var user in users)
            {
                userRoles.Add(new IdentityUserRole<Guid>
                {
                    UserId = user.Id,
                    RoleId = IdentityRoles.First().Id
                });
            }

            IdentityUserRoles.AddRange(userRoles);
            IsCalled = true;
        }
    }
}
