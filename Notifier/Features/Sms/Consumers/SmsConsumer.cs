using MassTransit;
using Notifier.Common.Bases;
using Notifier.Common.Inbox;

namespace Notifier.Features.Sms.Consumers;

public class SmsConsumer(InboxService inboxService) : 
    IConsumer<SmsNotify>,
    IConsumer<Fault<SmsNotify>>
{
    private readonly InboxService _inboxService = inboxService;
    public async Task Consume(ConsumeContext<SmsNotify> context)
    {
        if (await _inboxService.FindMessage(context.Message, context.CancellationToken))
            return;

        var inboxMessage = InboxMessage.Create(context.Message);
        await _inboxService.CreateAsync(inboxMessage, context.CancellationToken);
    }
    public async Task Consume(ConsumeContext<Fault<SmsNotify>> context)
    {
        // update the dashboard
    }
}
public record SmsNotify(Guid MessageId, string Mobile, string Message):NotifyBaseMessage(MessageId);

