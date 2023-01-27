using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpMeApp.DatabaseAccess.Entities.SenderRoleEntity
{
    public class SenderRoleConfiguration : IEntityTypeConfiguration<SenderRole>
    {
        public void Configure(EntityTypeBuilder<SenderRole> builder)
        {
            builder
               .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired();
        }
    }
}
