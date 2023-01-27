using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpMeApp.DatabaseAccess.Entities.ReportEntity
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.UserId)
                .IsRequired();

            builder
                .Property(x => x.AdvertId) 
                .IsRequired();

            builder
                .Property(x => x.Text);
        }
    }
}
