namespace Infra.MessageBus.Consumer
{
    public interface IMessageBusConsumer
    {
        Task ExecuteAsync<TCommand>(string source, CancellationToken cancellationToken);
    }
}
