using Notifier.Common.Persistence;

namespace Notifier.Features.Sms;

public class SMSService(ISMSProvider smsProvider, NotifierDbContext dbContext)
{
    public async Task SendAsync(string mobileNumber, string message, CancellationToken cancellationToken)
    {
        var referenceId = await smsProvider.SendAsync(mobileNumber, message, cancellationToken);
        if (referenceId is null)
            throw new InvalidOperationException();
        var smsTrace = SmsTrace.Create(mobileNumber, message, referenceId);
        dbContext.SmsTrace.Add(smsTrace);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
