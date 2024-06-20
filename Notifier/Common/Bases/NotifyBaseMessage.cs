namespace Notifier.Common.Bases;

public record NotifyBaseMessage(Guid MessageId) : INotify;

