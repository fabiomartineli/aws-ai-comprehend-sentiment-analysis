using Infra.MessageBus.Client;
using Infra.MessageBus.Consumer;
using Infra.MessageBus.Publisher;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infra.MessageBus
{
    public static class IoCExtension
    {
        public static IServiceCollection AddIoCMessageBus(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = new MessageBusSettings { ConnectionString = configuration.GetConnectionString(MessageBusSettings.SectionName) };
            services.AddSingleton(Options.Create(settings));
            services.AddSingleton<IMessageBusClient, MessageBusClient>();
            services.AddSingleton<IMessageBusConsumer, MessageBusConsumer>();
            services.AddSingleton<IMessageBusProducer, MessageBusProducer>();

            return services;
        }
    }
}
