using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpMeApp.Repositories.Entities.UserEntity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
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

            //builder
              //  .Property(x => x.PhotoId);

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

            //builder
            //    .HasMany(x => x.Adverts)
            //    .WithOne(x => x.Creator)
            //    .HasForeignKey(x => x.CreatorId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder
            //    .HasMany(x => x.Reports)
            //    .WithOne(x => x.User)
            //    .HasForeignKey(x => x.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Chatters)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
