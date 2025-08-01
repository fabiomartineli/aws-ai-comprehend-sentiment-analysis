using Domain.Commands.Base;
using Infra.MessageBus.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infra.MessageBus.Consumer
{
    internal class MessageBusConsumer : IMessageBusConsumer
    {
        private readonly IMessageBusClient _client;
        private readonly IServiceScopeFactory _serviceProvider;
        private readonly ILogger<MessageBusConsumer> _logger;

        public MessageBusConsumer(IMessageBusClient client,
            IServiceScopeFactory serviceProvider,
            ILogger<MessageBusConsumer> logger)
        {
            _client = client;
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task ExecuteAsync<TCommand>(string source, CancellationToken cancellationToken)
        {
            var consumer = _client.Client.CreateProcessor(source, new Azure.Messaging.ServiceBus.ServiceBusProcessorOptions()
            {
                PrefetchCount = 0,
                ReceiveMode = Azure.Messaging.ServiceBus.ServiceBusReceiveMode.PeekLock
            });

            consumer.ProcessMessageAsync +=  async (args) =>
            {
                using var scope = _serviceProvider.CreateAsyncScope();

                var body = args.Message.Body.ToObjectFromJson<TCommand>();
                var result = await scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand, bool>>().ExecuteAsync(body, default);

                if (result)
                {
                    await args.CompleteMessageAsync(args.Message);
                }
                else
                {
                    await args.AbandonMessageAsync(args.Message);
                }
            };

            consumer.ProcessErrorAsync += async (args) =>
            {
                _logger.LogError("[MESSAGE BUS] Error - {path} - {error}", args.EntityPath, args.Exception?.Message);
            };

            await consumer.StartProcessingAsync(cancellationToken);
        }
    }
}
