using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using Notifier.Common.Inbox;

namespace Notifier.Common.Persistence;

public class InboxMessageMap : IEntityTypeConfiguration<InboxMessage>
{
    public void Configure(EntityTypeBuilder<InboxMessage> builder)
    {
        builder.ToCollection("inbox_messages");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.MessageId)
            .ValueGeneratedOnAdd();
    }
}
