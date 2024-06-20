namespace Notifier.Features.Sms.SendSms;

public record SendSmsRequest(string mobileNumber, string message);
