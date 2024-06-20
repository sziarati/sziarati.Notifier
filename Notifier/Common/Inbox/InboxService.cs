using Microsoft.EntityFrameworkCore;
using Notifier.Common.Bases;
using Notifier.Common.Persistence;

namespace Notifier.Common.Inbox;

public class InboxService(NotifierDbContext dbContext)
{
    public async Task CreateAsync(InboxMessage inboxMessage, CancellationToken cancellationToken = default)
    {
        await dbContext.InboxMessages.AddAsync(inboxMessage, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> FindMessage<TMessage>(TMessage message, CancellationToken cancellationToken) where TMessage : NotifyBaseMessage
    {
        var result = await dbContext.InboxMessages.AnyAsync(i => i.MessageId == message.MessageId, cancellationToken);
        return result;
    }

    public async Task<List<InboxMessage>> GetUnProcessedMessagesAsync(CancellationToken cancellationToken)
    {
        return await dbContext.InboxMessages.Where(x => !x.IsProcessed)
                               .ToListAsync(cancellationToken);  
    }

    public void ProcessMessageAsync(InboxMessage message)
    {
        message.Process();
    }
}
