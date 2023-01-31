using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpMeApp.DatabaseAccess.Entities.AdvertEntity
{
    public class AdvertConfiguration : IEntityTypeConfiguration<Advert>
    {
        public void Configure(EntityTypeBuilder<Advert> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasMany(x => x.Photos)
                .WithOne(x => x.Advert)
                .HasForeignKey(x => x.AdvertId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.CreationDate)
                .HasDefaultValue(DateTime.Now);

            builder
                .Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder
                .HasMany(x => x.Reports)
                .WithOne(x => x.Advert)
                .HasForeignKey(x => x.AdvertId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(x => x.Chats)
                .WithOne(x => x.Advert)
                .HasForeignKey(x => x.AdvertId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
