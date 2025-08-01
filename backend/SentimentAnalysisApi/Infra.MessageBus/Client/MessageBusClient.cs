using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Options;

namespace Infra.MessageBus.Client
{

    internal class MessageBusClient : IMessageBusClient
    {
        private readonly ServiceBusClient _client;

        public MessageBusClient(IOptions<MessageBusSettings> settings)
        {
            _client = new(settings.Value.ConnectionString);
        }

        public ServiceBusClient Client => _client;
    }
}
