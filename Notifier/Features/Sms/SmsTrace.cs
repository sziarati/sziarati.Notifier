using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;

namespace Notifier.Features.Sms;

[Collection("sms_traces")]
public class SmsTrace
{
    public ObjectId Id { get; set; }
    public string Mobile { get; set; }
    public string Message { get; set; }
    public string ReferenceId { get; set; }
    public SmsStatus Status { get; set; }
    public DateTime CreatedOn { get; set; }
    public static SmsTrace Create(string mobile, string message, string referenceId)
    {
        var smsTrace = new SmsTrace
        {
            Mobile = mobile,
            Message = message,
            ReferenceId = referenceId,
        };

        return smsTrace;
    }
}

public enum SmsStatus
{
    delivered = 0 ,
    failed = 1,


}