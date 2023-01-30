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

namespace HelpMeApp.Repositories
{
    public class HelpMeDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {

        public HelpMeDbContext(DbContextOptions<HelpMeDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

        public DbSet<Advert> Adverts { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Chat> Chats { get; set; } = null!;
        public DbSet<HelpType> HelpTypes { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;
        public DbSet<Photo> Photos { get; set; } = null!;
        public DbSet<Report> Reports { get; set; } = null!;
        public DbSet<SenderRole> SenderRoles { get; set; } = null!;
        public DbSet<Terms> Terms { get; set; } = null!;
    }
}
