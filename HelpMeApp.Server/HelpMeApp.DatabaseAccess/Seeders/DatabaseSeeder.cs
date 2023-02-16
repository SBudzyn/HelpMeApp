using System;
using System.Collections.Generic;
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
            new IdentityRole<Guid>() { Name = "User", NormalizedName = "User" },
            new IdentityRole<Guid>() { Name = "Admin", NormalizedName = "Admin" },
        };

        public static List<IdentityUserRole<Guid>> IdentityUserRoles = new List<IdentityUserRole<Guid>>();

        public static List<Category> Categories = new List<Category>()
        {
            new Category(){ Name = "Food" },
            new Category(){ Name = "Clothes" },
            new Category(){ Name = "Evacuation" },
            new Category(){ Name = "Repairs" }
        };

        public static List<HelpType> HelpTypes = new List<HelpType>()
        {
            new HelpType(){ Name = "NeedHelp" },
            new HelpType(){ Name = "CanHelp" }
        };

        public static List<SenderRole> SenderRoles = new List<SenderRole>()
        {
            new SenderRole(){ Name = "Creator" },
            new SenderRole(){ Name = "Responder" },
            new SenderRole(){ Name = "System" }
        };

        public static List<Terms> Terms = new List<Terms>()
        {
            new Terms(){ Days = "1" },
            new Terms(){ Days = "2-3" },
            new Terms(){ Days = "5-7" },
            new Terms(){ Days = "10-20" },
            new Terms(){ Days = "21-30" },
        };

        public static void Init()
        {
            Randomizer.Seed = new Random(10000);

            var reportFaker = new Faker<Report>("uk")
                .RuleFor(r => r.Text, f => f.Lorem.Sentences(f.Random.Number(1, 5)));

            Reports.AddRange(reportFaker.Generate(25));

            var messageFaker = new Faker<Message>("uk")
                .RuleFor(m => m.SenderRoleId, f => f.PickRandom(SenderRoles).Id)
                .RuleFor(m => m.Text, f => f.Lorem.Sentences(f.Random.Number(1, 5)))
                .RuleFor(m => m.CreationDate, f => f.Date.Recent());

            Messages.AddRange(messageFaker.Generate(100));

            var chatId = 1;
            var chatFaker = new Faker<Chat>("uk")
                .RuleFor(c => c.Id, _ => chatId++)
                .RuleFor(c => c.IsConfirmedBySecondSide, f => f.PickRandom(true, false))
                .RuleFor(c => c.IsConfirmedByCreator, f => f.PickRandom(true, false));

            Chats.AddRange(chatFaker.Generate(300));

            var advertFaker = new Faker<Advert>("uk")
               .RuleFor(a => a.Header, f => f.Hacker.Phrase())
               .RuleFor(a => a.Info, f => f.Hacker.Phrase())
               .RuleFor(a => a.Location, f => f.Address.City())
               .RuleFor(a => a.HelpTypeId, f => f.PickRandom(HelpTypes).Id)
               .RuleFor(a => a.CategoryId, f => f.PickRandom(Categories).Id)
               .RuleFor(a => a.TermsId, f => f.PickRandom(Terms).Id)
               .RuleFor(a => a.CreationDate, f => f.Date.Between(new DateTime(2023, 01, 01), new DateTime(2023, 01, 25)))
               .RuleFor(a => a.ClosureDate, f => f.PickRandom(default, f.Date.Between(new DateTime(2023, 01, 26), new DateTime(2023, 02, 10))));

            Adverts.AddRange(advertFaker.Generate(1000));

            var hasher = new PasswordHasher<AppUser>();
            var appUserFaker = new Faker<AppUser>("uk")
               .RuleFor(u => u.Name, f => f.Name.FirstName())
               .RuleFor(u => u.Surname, f => f.Name.LastName())
               .RuleFor(u => u.RegistrationDate, f => f.Date.Past())
               .RuleFor(u => u.Info, f => f.Hacker.Phrase())
               .RuleFor(u => u.IsBlocked, f => f.PickRandom(true, false))
               .RuleFor(u => u.UserName, (f, p) => f.Internet.UserName(p.Name, p.Surname))
               .RuleFor(u => u.Email, (f, p) => f.Internet.Email(p.Name, p.UserName))
               .RuleFor(u => u.PasswordHash, f => hasher.HashPassword(null, "admin"))
               .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber());

            var users = appUserFaker.Generate(300);
            AppUsers.AddRange(users);
        }
    }
}
