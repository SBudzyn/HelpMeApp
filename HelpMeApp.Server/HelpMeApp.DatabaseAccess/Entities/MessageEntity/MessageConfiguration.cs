using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpMeApp.DatabaseAccess.Entities.MessageEntity
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.SenderRole)
                .WithMany(x => x.Messages)
                .HasForeignKey(x => x.SenderRoleId);

            builder
                .Property(x => x.CreationDate) 
                .HasDefaultValue(DateTime.Now);
        }
    }
}
