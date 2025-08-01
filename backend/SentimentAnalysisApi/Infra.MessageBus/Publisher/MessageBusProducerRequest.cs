namespace Infra.MessageBus.Publisher
{
    public sealed record MessageBusProducerRequest<TContent>
    {
        public required string Destination { get; init; }
        public required TContent Content { get; init; }
    }
}
