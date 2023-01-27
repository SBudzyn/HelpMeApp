using Microsoft.EntityFrameworkCore;
using HelpMeApp.DatabaseAccess.Entities.UserEntity;
using HelpMeApp.DatabaseAccess.Entities.ChatEntity;

namespace HelpMeApp.Repositories
{
    public class HelpMeDbContext : DbContext
    {

        public HelpMeDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ChatsConfiguration());
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Chat> Chats { get; set; } = null!;
    }
}
