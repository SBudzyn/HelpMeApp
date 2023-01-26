using Microsoft.EntityFrameworkCore;
using HelpMeApp.Repositories.Entities.UserEntity;
using HelpMeApp.Repositories.Entities.ChatterEntity;

namespace HelpMeApp.WebAPI
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
            modelBuilder.ApplyConfiguration(new ChattersConfiguration());
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Chatter> Chatters { get; set; } = null!;
    }
}
