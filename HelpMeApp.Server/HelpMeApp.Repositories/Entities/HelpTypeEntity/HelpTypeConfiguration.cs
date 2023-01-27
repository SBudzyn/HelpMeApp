using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpMeApp.DatabaseAccess.Entities.HelpTypeEntity
{
    public class HelpTypeConfiguration : IEntityTypeConfiguration<HelpType>
    {
        public void Configure(EntityTypeBuilder<HelpType> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired();
        }
    }
}
