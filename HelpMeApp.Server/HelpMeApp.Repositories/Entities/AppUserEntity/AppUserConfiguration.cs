using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpMeApp.DatabaseAccess.Entities.AppUserEntity
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired();

            builder
                .Property(x => x.Surname)
                .IsRequired();

            builder
                .Property(x => x.Phone);

            builder
                .Property(x => x.Email)
                .IsRequired();

            builder
                .Property(x => x.Photo);

            builder
                .Property(x => x.RegistrationDate)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

            builder
                .Property(x => x.Info);

            builder
                .Property(x => x.IsBlocked)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .HasMany(x => x.Adverts)
                .WithOne(x => x.Creator)
                .HasForeignKey(x => x.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(x => x.Reports)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(x => x.Chats)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
