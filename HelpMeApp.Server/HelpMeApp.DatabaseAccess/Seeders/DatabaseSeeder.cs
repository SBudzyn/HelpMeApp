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
                "I can provide you with drinking water. I can give you as much drinking water as you need. I have a well on my yard. It is absolutely free, of course.",
                "If you need fresh fruits and vegetables. I own a shop with fruits and vegetables. You can come and I will give you a little bit of everything!",
                "I have extra clothing for you. I have a large collection of clothing that I would be happy to give to refugees in need.",
                "Do you need blankets and bedding?. I have blankets and bedding that are in good condition and I would be happy to give them to refugees in need.",
                "I can give you hygiene products. I have a variety of hygiene products, such as soap and shampoo, that I would be happy to give to refugees in need.",
                "I have furniture for you. I have furniture that is in good condition and I would be happy to give it to refugees in need.",
                "Hey! Do you need Bicycles?. I have bicycles that are in good condition and I would be happy to give them to refugees in need.",
                "I can ptovide you with transportation. I can provide transportation to refugees who need it, such as to appointments or job interviews.",
                "Language Lessons FOR FREE. I can offer language lessons to refugees who want to learn a new language.",
                "I am Job Search Assistant, let me help you. I can help refugees with their job search by reviewing resumes, providing job leads, and offering interview tips.",
                "I can give you some pieces of legal advice. I can offer legal advice to refugees who may be dealing with immigration issues or other legal matters.",
                "I can help you with childcare. I can provide childcare to refugees who need it, such as while they attend appointments or job interviews.",
                "Do you need help with pet care?. I can provide pet care to refugees who need it, such as feeding and walking their pets.",
                "I can help you with medical assistance. I can provide medical assistance to refugees who may not have access to healthcare.",
                "I can provide you some counseling help. I can offer counseling services to refugees who may be dealing with trauma or other emotional issues.",
                "If you need any translation services. I can offer translation services to refugees who may need help communicating in a new language.",
                "If you need help with technology support for your job. I can offer technology support to refugees who may not be familiar with using computers or the internet.",
                "Interest club for you and your mental health!. I can offer entertainment options to refugees who may need a break from their daily routines, such as movie nights or game nights.",
                "I organize community events for you. I can organize community events for refugees to meet and connect with others in their new community.",
                "I can provide you with legal documents assistance. I can help refugees with the paperwork required for visas, passports, and other legal documents.",
                "If your children needs help with tutoring. I can offer tutoring services to refugee children who may need extra help with schoolwork.",
                "Do you need some art lessons?. I can offer art lessons to refugees who want to explore their creativity and express themselves through art.",
                "Let's go to music lessons together. I can offer music lessons to refugees who want to learn how to play an instrument or sing.",
                "Fitness classes for your mental and physical help. I can offer fitness classes to refugees who want to stay active and healthy.",
                "I am a dentist, if you need consultation come to me. I can offer dental care to refugees who may not have access to dental services.",
                "My hospital can help you with eye care. I can offer eye care to refugees who may not have access to eye exams or glasses."
            };

            var advertHeadersNeedsHelp = new[] {
                "I need food, please help. I need help feeding my family. Any assistance would be greatly appreciated.",
                "I need shelter very much. I need a safe place to stay. Any help finding housing would be greatly appreciated.",
                "My kids almost have no clothes. I am in need of clothing for myself and my family.",
                "Please help with medical assistance. I am in need of medical assistance for myself and a family member.",
                "Do you have extra hygiene products?. I am in need of hygiene products, such as soap and shampoo.",
                "Please help me to find a job. I am a refugee of war and I need help finding employment.",
                "I need some advices from lawyer. I am a refugee of war and I need legal advice regarding my immigration status or other legal matters.",
                "Do you know any language lessons?. I need help learning the language of my new country.",
                "I need babysitter for few hours a day. I need help with childcare while I attend appointments or job interviews.",
                "I need food for my cats. I need help with pet care, such as feeding and walking my pets.",
                "I have big emotional issues. I need counseling services to help me deal with trauma and emotional issues related to my experience as a refugee of war.",
                "Please help with translation. I need help communicating in the language of my new country.",
                "My grandma needs help with techonoligies. I need help how to learn my grandma use computers and the internet.",
                "Is there any interest clubs?. I need help finding entertainment options to help me cope with the stress.",
                "I want to visit local community events. I need help finding and participating in community events to meet and connect with others in my new country.",
                "I need legal documents assistance. I need help with paperwork related to my immigration status or other legal documents.",
                "I need a tutor for my children. I need tutoring services for my children who may need extra help with schoolwork.",
                "Is there any art lessons?. I need help finding and participating in art lessons to express myself creatively.",
                "I am looking for music lessons for my son. I need help finding and participating in music lessons to learn how to play an instrument or sing.",
                "I am looking for fitness classes. I need help finding and participating in fitness classes to stay healthy and active.",
                "I need dentist consultaion. I need help finding for dental care.",
                "I have problems with my eyes, where can i find a doctor?. I need help finding eye exams and glasses.",
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

            var phoneNumbers = new[]
            {
                "380998664275", "380958465131", "380948664275", "380974862153",
                "380997861176", "380958468499", "380948664275", "380974845684",
                "380995921563", "380951354986", "380941354886", "380972135486",
                "380994153565", "380958475123", "380941231545", "380971654846",
                "380991651879", "380958451668", "380948745621", "380978468456",
                "380991654984", "380951535148", "380943211486", "380976185412",
                "380994135194", "380956954681", "380948895475", "380973514684",
                "380991894685", "380951651847", "380943218456", "380971864651",
                "380996894581", "380959564843", "380948745612", "380974684487",
                "380996468412", "380951548331", "380941848688", "380971564846"
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
               .RuleFor(u => u.PhoneNumber, f => f.PickRandom(phoneNumbers));

            var users = appUserFaker.Generate(300);
            AppUsers.AddRange(users);
        }
    }
}
