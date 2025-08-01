using Azure.Messaging.ServiceBus;

namespace Infra.MessageBus.Client
{
    internal interface IMessageBusClient
    {
        ServiceBusClient Client { get; }
    }
}
