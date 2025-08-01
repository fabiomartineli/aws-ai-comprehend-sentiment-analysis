using Domain.Events;
using Domain.Events.Base;
using Infra.MessageBus.Publisher;

namespace Application.Events
{
    public class ProductReviewedHandler : IDomainEventHandler<ProductReviewedEvent>
    {
        private readonly IMessageBusProducer _messageBusProducer;

        public ProductReviewedHandler(IMessageBusProducer messageBusProducer)
        {
            _messageBusProducer = messageBusProducer;
        }

        public async Task ExecuteAsync(ProductReviewedEvent @event, CancellationToken cancellationToken)
        {
            await _messageBusProducer.ExecuteAsync(new MessageBusProducerRequest<ProductReviewedEvent>
            {
                Content = @event,
                Destination = "product-reviewed-sentiment-analysis"
            }, cancellationToken);
        }
    }
}
