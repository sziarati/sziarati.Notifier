using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using Notifier.Common.Bases;
using System.Text.Json;

namespace Notifier.Common.Inbox;

[Collection("inbox_messages")]
public class InboxMessage
{
    public ObjectId Id { get; set; }
    public Guid MessageId { get; set; }
    public required string Type { get; set; }
    public required string Content { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsProcessed { get; set; }
    public static InboxMessage Create<TModel>(TModel model) where TModel : NotifyBaseMessage
    {
        return new InboxMessage
        {
            CreatedOn = DateTime.Now,
            Content = JsonSerializer.Serialize(model),
            IsProcessed = false,
            Type = typeof(TModel).FullName,
            MessageId = model.MessageId,
        };
    }

    public void Process() => IsProcessed = true;
}
