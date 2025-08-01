namespace Infra.MessageBus.Publisher
{
    public interface IMessageBusProducer
    {
        Task ExecuteAsync<TContent>(MessageBusProducerRequest<TContent> request, CancellationToken cancellationToken);
    }
}
