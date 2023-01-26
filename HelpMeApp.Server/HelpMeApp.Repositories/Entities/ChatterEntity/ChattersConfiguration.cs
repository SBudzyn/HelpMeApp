using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpMeApp.Repositories.Entities.ChatterEntity
{
    public class ChattersConfiguration : IEntityTypeConfiguration<Chatter>
    {
        public void Configure(EntityTypeBuilder<Chatter> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.UserId)
                .IsRequired();

            builder
                .Property(x => x.IsConfirmedBySecondSide)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property(x => x.IsConfirmedByCreator)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
