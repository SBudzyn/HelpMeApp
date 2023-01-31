using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpMeApp.DatabaseAccess.Entities.HelpTypeEntity
{
    public class HelpTypeConfiguration : IEntityTypeConfiguration<HelpType>
    {
        public void Configure(EntityTypeBuilder<HelpType> builder)
        {
            builder
                .HasKey(x => x.Id);
        }
    }
}
