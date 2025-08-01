namespace Infra.MessageBus.Client
{
    internal sealed record MessageBusSettings
    {
        public const string SectionName = "ServiceBus";
        public required string ConnectionString { get; init; }
    }
}
