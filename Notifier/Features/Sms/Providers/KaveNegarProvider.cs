using Notifier.Features.Sms;

namespace sziarati.Notifier.Features.SMS;

public class KaveNegarProvider : ISMSProvider
{
    public static string ProviderName { set => throw new NotImplementedException(); }

    public Task<bool> InquiryAsync(string smsId)
    {
        throw new NotImplementedException();
    }

    public Task<string> SendAsync(string mobileNumber, string message, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}