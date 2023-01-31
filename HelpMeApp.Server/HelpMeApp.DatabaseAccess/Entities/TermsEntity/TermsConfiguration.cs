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
        }
    }
}
