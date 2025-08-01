using Amazon.Comprehend;
using Microsoft.Extensions.Options;

namespace Infra.AI.Clients
{
    internal class ComprehendClient : IComprehendClient
    {
        private readonly AmazonComprehendClient _client;

        public ComprehendClient(IOptions<ComprehendClientSettings> settings)
        {
            _client = new(settings.Value.AccessKey, settings.Value.SecretKey);
        }

        public AmazonComprehendClient Client => _client;
    }
}
