using Microsoft.Extensions.Options;
using Notifier;
using Notifier.Features.Sms;
using PayamakCore.Dto;
using PayamakCore.Interface;

namespace sziarati.Notifier.Features.SMS;

public class FaraPayamakProvider(IOptions<AppSettings> options, IPayamakServices payamakServices) : ISMSProvider
{
    private readonly IPayamakServices _payamakServices = payamakServices;
    private readonly IOptions<AppSettings> _options = options;
    private readonly Farapayamak farapayamek = options.Value.FeatureConfiguration.SmsConfiguration.Farapayamak;
    public static string Name { set => throw new NotImplementedException(); }

    public async Task<bool> InquiryAsync(string smsId)
    {
        long.TryParse(smsId, out long recId);
        var deliverRequestDto = new DeliverRequestDto
        {
            RecId = recId,
            username = farapayamek.Username,
            password = farapayamek.Password,
        };
        var status = await _payamakServices.GetMessageStatus(deliverRequestDto);

        return status.RetStatus > 0 ? true : false;
    }

    public async Task<string> SendAsync(string mobileNumber, string message, CancellationToken cancellationToken)
    {
        var messageDto = new MessageDto
        {
            From = mobileNumber,
            To = mobileNumber,
            username = farapayamek.Username,
            password = farapayamek.Password,
            Text = message,
        };

        var result = await _payamakServices.SendSms(messageDto, cancellationToken);
        return result.StrRetStatus;
    }
}
