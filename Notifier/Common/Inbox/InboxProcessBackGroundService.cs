using MediatR;
using Notifier.Common.Bases;
using System.Reflection;
using System.Text.Json;

namespace Notifier.Common.Inbox;

public class InboxProcessBackGroundService(IServiceProvider serviceProvider) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var scope = serviceProvider.CreateScope();
        var _inboxService = scope.ServiceProvider.GetRequiredService<InboxService>();
        var _mediator= scope.ServiceProvider.GetRequiredService<IMediator>();


        var messages = await _inboxService.GetUnProcessedMessagesAsync(stoppingToken);
        foreach (var message in messages)
        {
            var messageType = Assembly.GetExecutingAssembly().GetType(message.Type);
            if (messageType == null)
            {
                //log
                return;
            }
            var messageContent = JsonSerializer.Deserialize(message.Content, messageType);
            if(messageContent is INotify notify)
            {
                await _mediator.Publish(notify, stoppingToken);
                _inboxService.ProcessMessageAsync(message);
            }
        }
    }
}