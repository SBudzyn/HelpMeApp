using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpMeApp.DatabaseAccess.Entities.ChatEntity
{
    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder
                .HasKey(x => new { x.Id, x.UserId, x.AdvertId });

            builder
                .Property(x => x.IsConfirmedBySecondSide)
                .HasDefaultValue(false);

            builder
                .Property(x => x.IsConfirmedByCreator)
                .HasDefaultValue(false);

            builder
                .HasMany(x => x.Messages)
                .WithOne(x => x.Chat)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.ChatId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
