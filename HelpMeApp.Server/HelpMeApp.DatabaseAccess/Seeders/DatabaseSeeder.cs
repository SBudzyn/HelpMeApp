using System;
using System.Collections.Generic;
using Bogus;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;
using HelpMeApp.DatabaseAccess.Entities.CategoryEntity;
using HelpMeApp.DatabaseAccess.Entities.ChatEntity;
using HelpMeApp.DatabaseAccess.Entities.HelpTypeEntity;
using HelpMeApp.DatabaseAccess.Entities.MessageEntity;
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
            new HelpType(){ Name = "Need help" },
            new HelpType(){ Name = "Can help" }
        };

        public static List<SenderRole> SenderRoles = new List<SenderRole>()
        {
            new SenderRole(){ Name = "Creator" },
            new SenderRole(){ Name = "Responder" },
            new SenderRole(){ Name = "System" }
        };

        public static List<Terms> Terms = new List<Terms>()
        {
            new Terms(){ From = "1", Till = "2" },
            new Terms(){ From = "3", Till = "4" },
            new Terms(){ From = "5", Till = "7" },
            new Terms(){ From = "10", Till = "20" },
            new Terms(){ From = "21", Till = "30" },
        };

        public static void Init()
        {
            Randomizer.Seed = new Random(10000);

            var advertHeadersCanHelp = new[] {
                "Drinking water. I can give you as much drinking water as you need. I have a well on my yard. It is absolutely free, of course.",
                "Fresh fruits and vegetables. I own a shop with fruits and vegetables. You can come and I will give you a little bit of everything!",
                "Clothing. I have a large collection of clothing that I would be happy to give to refugees in need.",
                "Blankets and Bedding. I have blankets and bedding that are in good condition and I would be happy to give them to refugees in need.",
                "Hygiene Products. I have a variety of hygiene products, such as soap and shampoo, that I would be happy to give to refugees in need.",
                "Furniture. I have furniture that is in good condition and I would be happy to give it to refugees in need.",
                "Bicycles. I have bicycles that are in good condition and I would be happy to give them to refugees in need.",
                "Transportation. I can provide transportation to refugees who need it, such as to appointments or job interviews.",
                "Language Lessons. I can offer language lessons to refugees who want to learn a new language.",
                "Job Search Assistance. I can help refugees with their job search by reviewing resumes, providing job leads, and offering interview tips.",
                "Legal Advice. I can offer legal advice to refugees who may be dealing with immigration issues or other legal matters.",
                "Childcare. I can provide childcare to refugees who need it, such as while they attend appointments or job interviews.",
                "Financial Assistance. I can provide financial assistance to refugees who may be struggling to make ends meet.",
                "Pet Care. I can provide pet care to refugees who need it, such as feeding and walking their pets.",
                "Housekeeping. I can offer housekeeping services to refugees who may not have the time or energy to keep their homes clean.",
                "Medical Assistance. I can provide medical assistance to refugees who may not have access to healthcare.",
                "Counseling. I can offer counseling services to refugees who may be dealing with trauma or other emotional issues.",
                "Translation Services. I can offer translation services to refugees who may need help communicating in a new language.",
                "Technology Support. I can offer technology support to refugees who may not be familiar with using computers or the internet.",
                "Entertainment. I can offer entertainment options to refugees who may need a break from their daily routines, such as movie nights or game nights.",
                "Cooking Assistance. I can offer cooking assistance to refugees who may need help preparing meals or learning how to cook new dishes.",
                "Community Events. I can organize community events for refugees to meet and connect with others in their new community.",
                "Legal Documents Assistance. I can help refugees with the paperwork required for visas, passports, and other legal documents.",
                "Resume Building. I can help refugees build their resumes and improve their chances of finding employment.",
                "Tutoring. I can offer tutoring services to refugee children who may need extra help with schoolwork.",
                "Art Lessons. I can offer art lessons to refugees who want to explore their creativity and express themselves through art.",
                "Music Lessons. I can offer music lessons to refugees who want to learn how to play an instrument or sing.",
                "Fitness Classes. I can offer fitness classes to refugees who want to stay active and healthy.",
                "Dental Care. I can offer dental care to refugees who may not have access to dental services.",
                "Eye Care. I can offer eye care to refugees who may not have access to eye exams or glasses."
            };

            var advertHeadersNeedsHelp = new[] {
                "Food. I need help feeding my family. Any assistance would be greatly appreciated.",
                "Shelter. I need a safe place to stay. Any help finding housing would be greatly appreciated.",
                "Clothing. I am in need of clothing for myself and my family.",
                "Medical Assistance. I am in need of medical assistance for myself or a family member.",
                "Hygiene Products. I am in need of hygiene products, such as soap and shampoo.",
                "Transportation. I need help getting to appointments or job interviews.",
                "Job Search Assistance. I am a refugee of war and I need help finding employment.",
                "Legal Advice. I am a refugee of war and I need legal advice regarding my immigration status or other legal matters.",
                "Language Lessons. I need help learning the language of my new country.",
                "Childcare. I need help with childcare while I attend appointments or job interviews.",
                "Financial Assistance. I need financial assistance to pay for basic necessities such as rent and food.",
                "Pet Care. I need help with pet care, such as feeding and walking my pets.",
                "Housekeeping. I need help with housekeeping tasks such as cleaning and laundry.",
                "Counseling. I need counseling services to help me deal with trauma and emotional issues related to my experience as a refugee of war.",
                "Translation Services. I need help communicating in the language of my new country.",
                "Technology Support. I need help learning how to use computers and the internet.",
                "Entertainment. I need help finding entertainment options to help me cope with the stress of being a refugee of war.",
                "Cooking Assistance. I need help learning how to cook in the style of my new country.",
                "Community Events. I need help finding and participating in community events to meet and connect with others in my new country.",
                "Legal Documents Assistance. I need help with paperwork related to my immigration status or other legal documents.",
                "Resume Building. I need help building my resume and finding employment in my new country.",
                "Tutoring. I need tutoring services for my children who may need extra help with schoolwork.",
                "Art Lessons. I need help finding and participating in art lessons to express myself creatively.",
                "Music Lessons. I need help finding and participating in music lessons to learn how to play an instrument or sing.",
                "Fitness Classes. I need help finding and participating in fitness classes to stay healthy and active.",
                "Dental Care. I need help finding and paying for dental care.",
                "Eye Care. I need help finding and paying for eye exams and glasses.",
                "Assistance with Immigration. I need help navigating the immigration process in my new country.",
                "Legal Aid. I need help finding a lawyer to represent me in legal matters related to my status as a refugee of war."
            };

            var Towns = new[]
            {
                "Kyiv", "Kharkiv", "Lviv", "Odesa", "Kherson", "Vinnytsia", "Donets'k", "Luhans'k", "Dnipro", "Kryvyi Rih", "Sevastopol'",
                "Makiivka", "Mykolaiv", "Zaporizhzhia", "Simferopol'", "Chernihiv", "Poltava", "Khmelnytskyi", "Cherkasy", "Chernivtsi",
                "Zhytomyr", "Sumy", "Rivne", "Horlivka", "Ivano-Frankivs'k", "Ternopil'", "Kropyvnytskyi", "Luts'k"
            };

            var personalInfo = new[]
            {
                "Hi, I am a mechanic. In my free time, I enjoy hiking and exploring nature.",
                "I am a teacher. I love to read books and watch movies to relax.",
                "Hello, I am a software engineer. I am also an avid gamer and love to play video games.",
                "I am a painter. In my free time, I enjoy playing the piano and composing music.",
                "I am a musician. I also love to cook and experiment with new recipes.",
                "Hello, I am a chef. I enjoy practicing yoga and meditation to stay calm and focused.",
                "I am a student. I love to play basketball and stay active in my free time.",
                "I am a nurse. I enjoy practicing calligraphy and creating beautiful lettering.",
                "Hi, I am a soccer player. In my free time, I enjoy reading and writing poetry.",
                "I am a journalist. I love to travel and explore different cultures and cuisines.",
                "Hi, I am a carpenter. In my free time, I enjoy woodworking and building furniture for my home.",
                "I am a graphic designer. I also love to go on hikes and take photographs of the beautiful scenery.",
                "Hello, I am a baker. I enjoy playing guitar and writing songs in my free time.",
                "I am a writer. In my free time, I like to paint and express my creativity in a different way.",
                "I am a doctor. I also love to dance and attend salsa classes in my free time.",
                "Hello, I am a web developer. I enjoy practicing martial arts and staying active and fit.",
                "I am a sales representative. I love to play chess and participate in local tournaments.",
                "I am a therapist. In my free time, I enjoy gardening and growing my own fruits and vegetables.",
                "Hi, I am a construction worker. I enjoy playing basketball and watching sports with my friends.",
                "I am an accountant. I love to read and learn about new financial strategies and investments."
            };

            var reportFaker = new Faker<Report>()
                .RuleFor(r => r.Text, f => f.Lorem.Sentences(f.Random.Number(1, 5)));

            Reports.AddRange(reportFaker.Generate(25));

            var messageFaker = new Faker<Message>()
                .RuleFor(m => m.SenderRoleId, f => f.PickRandom(SenderRoles).Id)
                .RuleFor(m => m.Text, f => f.Lorem.Sentences(f.Random.Number(1, 5)))
                .RuleFor(m => m.CreationDate, f => f.Date.Recent());

            Messages.AddRange(messageFaker.Generate(100));

            var chatFaker = new Faker<Chat>()
                .RuleFor(c => c.IsConfirmedByResponder, f => f.PickRandom(true, false))
                .RuleFor(c => c.IsConfirmedByCreator, f => f.PickRandom(true, false));

            Chats.AddRange(chatFaker.Generate(300));

            var advertNeedsHelpFaker = new Faker<Advert>()
               .RuleFor(a => a.Header, f => f.PickRandom(advertHeadersNeedsHelp))
               .RuleFor(a => a.Location, f => f.PickRandom(Towns))
               .RuleFor(a => a.HelpTypeId, f => 1)
               .RuleFor(a => a.CategoryId, f => f.PickRandom(Categories).Id)
               .RuleFor(a => a.TermsId, f => f.PickRandom(Terms).Id)
               .RuleFor(a => a.CreationDate, f => f.Date.Between(new DateTime(2023, 02, 01), new DateTime(2023, 02, 21)))
               .RuleFor(a => a.ClosureDate, f => f.PickRandom(default, f.Date.Between(new DateTime(2023, 02, 02), new DateTime(2023, 02, 22))));

            var advertCanHelpFaker = new Faker<Advert>()
               .RuleFor(a => a.Header, f => f.PickRandom(advertHeadersCanHelp))
               .RuleFor(a => a.Location, f => f.PickRandom(Towns))
               .RuleFor(a => a.HelpTypeId, f => 2)
               .RuleFor(a => a.CategoryId, f => f.PickRandom(Categories).Id)
               .RuleFor(a => a.TermsId, f => f.PickRandom(Terms).Id)
               .RuleFor(a => a.CreationDate, f => f.Date.Between(new DateTime(2023, 02, 01), new DateTime(2023, 02, 21)))
               .RuleFor(a => a.ClosureDate, f => f.PickRandom(default, f.Date.Between(new DateTime(2023, 02, 02), new DateTime(2023, 02, 22))));

            Adverts.AddRange(advertNeedsHelpFaker.Generate(240));
            Adverts.AddRange(advertCanHelpFaker.Generate(225));

            var hasher = new PasswordHasher<AppUser>();
            var appUserFaker = new Faker<AppUser>()
               .RuleFor(u => u.Name, f => f.Name.FirstName())
               .RuleFor(u => u.Surname, f => f.Name.LastName())
               .RuleFor(u => u.RegistrationDate, f => f.Date.Past())
               .RuleFor(u => u.Info, f => f.PickRandom(personalInfo))
               .RuleFor(u => u.IsBlocked, f => f.PickRandom(true, false))
               .RuleFor(u => u.UserName, (f, p) => f.Internet.UserName(p.Name, p.Surname))
               .RuleFor(u => u.Email, (f, p) => f.Internet.Email(p.Name, p.UserName))
               .RuleFor(u => u.PasswordHash, f => hasher.HashPassword(null, "Admin123."))
               .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber());

            var users = appUserFaker.Generate(300);
            AppUsers.AddRange(users);
        }
    }
}
