﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                .Property(x => x.Header)
                .IsRequired();

            builder
                .Property(x => x.Info)
                .IsRequired();

            builder
                .Property(x => x.Location)
                .IsRequired();

            builder
                .Property(x => x.CreatorId);

            builder
                .Property(x => x.HelpTypeId);

            builder
                .Property(x => x.CategoryId);

            builder
                .Property(x => x.TermsId);

            builder
                .HasMany(x => x.Photos)
                .WithOne(x => x.Advert)
                .HasForeignKey(x => x.AdvertId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(x => x.CreationDate)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

            builder
                .Property(x => x.ClosureDate);

            builder
                .Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder
                .HasMany(x => x.Reports)
                .WithOne(x => x.Advert)
                .HasForeignKey(x => x.AdvertId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Chats)
                .WithOne(x => x.Advert)
                .HasForeignKey(x => x.AdvertId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
