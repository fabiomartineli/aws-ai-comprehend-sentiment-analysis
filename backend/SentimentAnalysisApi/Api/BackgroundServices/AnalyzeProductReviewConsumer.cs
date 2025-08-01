
using Domain.Commands;
using Infra.MessageBus.Consumer;

namespace Api.BackgroundServices
{
    public class AnalyzeProductReviewConsumer : BackgroundService
    {
        private readonly IMessageBusConsumer _consumer;

        public AnalyzeProductReviewConsumer(IMessageBusConsumer consumer)
        {
            _consumer = consumer;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _consumer.ExecuteAsync<AnalyzeProductReviewCommand>("product-reviewed-sentiment-analysis", stoppingToken);
        }
    }
}
