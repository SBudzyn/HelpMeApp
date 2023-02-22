using System;
using System.Linq;
using HelpMeApp.DatabaseAccess.Seeders;
using Microsoft.AspNetCore.Identity;

namespace HelpMeApp.DatabaseAccess.Initializers
{
    public class DbInitializer
    {
        public static void Initialize(HelpMeDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Adverts.Any())
            {
                return;
            }

            DatabaseSeeder.Init();

            context.Categories.AddRange(DatabaseSeeder.Categories);
            context.HelpTypes.AddRange(DatabaseSeeder.HelpTypes);
            context.SenderRoles.AddRange(DatabaseSeeder.SenderRoles);
            context.Terms.AddRange(DatabaseSeeder.Terms);
            context.Users.AddRange(DatabaseSeeder.AppUsers);
            context.Roles.AddRange(DatabaseSeeder.IdentityRoles);

            context.SaveChanges();

            foreach (var user in DatabaseSeeder.AppUsers)
            {
                context.UserRoles.Add(new IdentityUserRole<Guid>
                {
                    UserId = user.Id,
                    RoleId = DatabaseSeeder.IdentityRoles.First().Id
                });
            }

            foreach (var advert in DatabaseSeeder.Adverts)
            {
                advert.Info = advert.Header.Split(new[] {'.'}, 2)[1];
                advert.Header = advert.Header.Split(new[] {'.'}, 2)[0];
                advert.CreatorId = DatabaseSeeder.AppUsers[Random.Shared.Next(0, DatabaseSeeder.AppUsers.Count)].Id;
                advert.CategoryId = DatabaseSeeder.Categories[Random.Shared.Next(0, DatabaseSeeder.Categories.Count)].Id;
                advert.TermsId = DatabaseSeeder.Terms[Random.Shared.Next(0, DatabaseSeeder.Terms.Count)].Id;
                advert.IsClosed = advert.ClosureDate == DateTime.MinValue ? false : true;
            }
            context.Adverts.AddRange(DatabaseSeeder.Adverts);

            context.SaveChanges();

            foreach (var report in DatabaseSeeder.Reports)
            {
                var advert = DatabaseSeeder.Adverts[Random.Shared.Next(0, DatabaseSeeder.Adverts.Count)];
                report.AdvertId = advert.Id;
                var possibleUsers = DatabaseSeeder.AppUsers.Where(x => x.Id != advert.CreatorId).ToList();
                report.UserId = possibleUsers[Random.Shared.Next(0, possibleUsers.Count)].Id;
            }
            context.Reports.AddRange(DatabaseSeeder.Reports);

            foreach (var chat in DatabaseSeeder.Chats)
            {
                var advert = DatabaseSeeder.Adverts[Random.Shared.Next(0, DatabaseSeeder.Adverts.Count)];
                chat.AdvertId = advert.Id;
                var possibleUsers = DatabaseSeeder.AppUsers.Where(x => x.Id != advert.CreatorId).ToList();
                chat.UserId = possibleUsers[Random.Shared.Next(0, possibleUsers.Count)].Id;
            }
            context.Chats.AddRange(DatabaseSeeder.Chats);

            context.SaveChanges();

            foreach (var message in DatabaseSeeder.Messages)
            {
                message.SenderRoleId = DatabaseSeeder.SenderRoles[Random.Shared.Next(0, DatabaseSeeder.SenderRoles.Count)].Id;
                message.ChatId = DatabaseSeeder.Chats[Random.Shared.Next(0, DatabaseSeeder.Chats.Count)].Id;
            }
            context.Messages.AddRange(DatabaseSeeder.Messages);

            context.SaveChanges();
        }
    }
}
