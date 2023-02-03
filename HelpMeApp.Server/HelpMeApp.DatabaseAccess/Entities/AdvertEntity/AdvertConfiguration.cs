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
                .HasOne(x => x.HelpType)
                .WithMany(x => x.Adverts)
                .HasForeignKey(x => x.HelpTypeId);

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Adverts)
                .HasForeignKey(x => x.CategoryId);

            builder
                .HasOne(x => x.Terms)
                .WithMany(x => x.Adverts)
                .HasForeignKey(x => x.TermsId);

            builder
                .HasMany(x => x.Photos)
                .WithOne(x => x.Advert)
                .HasForeignKey(x => x.AdvertId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.CreationDate)
                .HasDefaultValue(DateTime.Now);

            builder
                .Property(x => x.IsClosed)
                .HasDefaultValue(false);

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
