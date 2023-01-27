using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpMeApp.DatabaseAccess.Entities.ChatEntity
{
    public class ChatsConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
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
                .Property(x => x.IsConfirmedBySecondSide)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property(x => x.IsConfirmedByCreator)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .HasMany(x => x.Messages)
                .WithOne(x => x.Chat)
                .HasForeignKey(x => x.ChatId)
                .OnDelete(DeleteBehavior.Cascade);
                
        }
    }
}
