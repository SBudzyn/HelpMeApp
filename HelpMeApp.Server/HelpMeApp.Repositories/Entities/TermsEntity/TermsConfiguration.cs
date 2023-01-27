using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpMeApp.DatabaseAccess.Entities.TermsEntity
{
    public class TermsConfiguration : IEntityTypeConfiguration<Terms>
    {
        public void Configure(EntityTypeBuilder<Terms> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Days)
                .IsRequired();
        }
    }
}
