namespace Notifier.Features.Sms;

public interface ISMSProvider
{
    public static string Name { get; set; } = null!;
    public Task<string> SendAsync(string mobileNumber, string message, CancellationToken cancellationToken);
    public Task<bool> InquiryAsync(string smsId);
}
