using Microsoft.EntityFrameworkCore;
using Notifier.Common.Inbox;
using Notifier.Features.Sms;
using System.Reflection;

namespace Notifier.Common.Persistence;

public class NotifierDbContext : DbContext
{
    public NotifierDbContext(DbContextOptions options) : base(options)
    {

    }
    
    public DbSet<SmsTrace> SmsTrace { get; set; }
    public DbSet<InboxMessage> InboxMessages { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
