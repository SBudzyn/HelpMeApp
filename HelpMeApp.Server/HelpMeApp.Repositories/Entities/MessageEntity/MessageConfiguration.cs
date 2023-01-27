using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                .Property(x => x.SenderRoleId)
                .IsRequired();

            builder
                .Property(x => x.ChatId)
                .IsRequired();

            builder
                .Property(x => x.Text)
                .IsRequired();

            builder
                .Property(x => x.CreationDate) 
                .IsRequired()
                .HasDefaultValue(DateTime.Now);
        }
    }
}
