using Microsoft.EntityFrameworkCore;
using HelpMeApp.DatabaseAccess.Entities.AppUserEntity;
using HelpMeApp.DatabaseAccess.Entities.ChatEntity;
using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using HelpMeApp.DatabaseAccess.Entities.CategoryEntity;
using HelpMeApp.DatabaseAccess.Entities.HelpTypeEntity;
using HelpMeApp.DatabaseAccess.Entities.MessageEntity;
using HelpMeApp.DatabaseAccess.Entities.PhotoEntity;
using HelpMeApp.DatabaseAccess.Entities.ReportEntity;
using HelpMeApp.DatabaseAccess.Entities.SenderRoleEntity;
using HelpMeApp.DatabaseAccess.Entities.TermsEntity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using HelpMeApp.DatabaseAccess.Seeders;

namespace HelpMeApp.Repositories
{
    public class HelpMeDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<HelpType> HelpTypes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<SenderRole> SenderRoles { get; set; }
        public DbSet<Terms> Terms { get; set; }
        public HelpMeDbContext(DbContextOptions<HelpMeDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if(!FakeData.IsCalled) FakeData.Init();

            modelBuilder.Entity<Advert>().HasData(FakeData.Adverts);
            modelBuilder.Entity<Category>().HasData(FakeData.Categories);
            modelBuilder.Entity<Chat>().HasData(FakeData.Chats);
            modelBuilder.Entity<HelpType>().HasData(FakeData.HelpTypes);
            modelBuilder.Entity<Message>().HasData(FakeData.Messages);
            modelBuilder.Entity<Report>().HasData(FakeData.Reports);
            modelBuilder.Entity<SenderRole>().HasData(FakeData.SenderRoles);
            modelBuilder.Entity<Terms>().HasData(FakeData.Terms);
            modelBuilder.Entity<AppUser>().HasData(FakeData.AppUsers);
            modelBuilder.Entity<IdentityRole<Guid>>().HasData(FakeData.IdentityRoles);
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(FakeData.IdentityUserRoles);

            modelBuilder.ApplyConfiguration(new AdvertConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ChatConfiguration());
            modelBuilder.ApplyConfiguration(new HelpTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new PhotoConfiguration());
            modelBuilder.ApplyConfiguration(new ReportConfiguration());
            modelBuilder.ApplyConfiguration(new SenderRoleConfiguration());
            modelBuilder.ApplyConfiguration(new TermsConfiguration());
        }
    }
}
