using Azure.Messaging.ServiceBus;
using Infra.MessageBus.Client;

namespace Infra.MessageBus.Publisher
{
    internal class MessageBusProducer : IMessageBusProducer
    {
        private readonly IMessageBusClient _client;
        private readonly Dictionary<string, ServiceBusSender> _senders;

        public MessageBusProducer(IMessageBusClient client)
        {
            _client = client;
            _senders = [];
        }

        public async Task ExecuteAsync<TContent>(MessageBusProducerRequest<TContent> request, CancellationToken cancellationToken)
        {
            if (!_senders.ContainsKey(request.Destination))
            {
                var newSender = _client.Client.CreateSender(request.Destination);
                _senders.Add(request.Destination, newSender);
            }

            if(_senders.TryGetValue(request.Destination, out var sender))
            {
                await sender.SendMessageAsync(new ServiceBusMessage
                {
                    Body = BinaryData.FromObjectAsJson(request.Content),
                    ContentType = "application/json"
                }, cancellationToken);
            }
        }
    }
}
