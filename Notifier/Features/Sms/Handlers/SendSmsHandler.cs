using MediatR;
using Notifier.Features.Sms;
using Notifier.Features.Sms.Consumers;

namespace sziarati.Notifier.Features.SMS;

public class SendSmsHandler(SMSService smsService) : INotificationHandler<SmsNotify> // INotificationHandler<NotifyBaseMessage>
{
    private readonly SMSService _smsService = smsService;
    public async Task Handle(SmsNotify smsNotify, CancellationToken cancellationToken)
    {
        await _smsService.SendAsync(smsNotify.Mobile, smsNotify.Message, cancellationToken);
    }
}
