namespace Infra.AI.Clients
{
    internal sealed record ComprehendClientSettings
    {
        public const string SectionName = "Aws:ComprehendSettings";
        public required string AccessKey { get; init; }
        public required string SecretKey { get; init; }
    }
}
