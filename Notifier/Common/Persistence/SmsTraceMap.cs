using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using Notifier.Features.Sms;

namespace Notifier.Common.Persistence;

public class SmsTraceMap : IEntityTypeConfiguration<SmsTrace>
{
    public void Configure(EntityTypeBuilder<SmsTrace> builder)
    {
        builder.ToCollection("sms_traces");
        builder.HasKey(p => p.Id);
    }
}
