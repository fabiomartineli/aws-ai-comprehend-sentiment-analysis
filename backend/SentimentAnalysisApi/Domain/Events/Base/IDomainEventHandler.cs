namespace Domain.Events.Base
{
    public interface IDomainEventHandler<in TEvent> where TEvent : IDomainEvent
    {
        Task ExecuteAsync(TEvent @event, CancellationToken cancellationToken);
    }
}
