using Amazon.Comprehend;
using Amazon.Runtime;
using Microsoft.Extensions.Options;

namespace Infra.AI.Clients
{
    internal class ComprehendClient : IComprehendClient
    {
        private readonly AmazonComprehendClient _client;

        public ComprehendClient(IOptions<ComprehendClientSettings> settings)
        {
            // Use AWS SDK credential provider chain instead of hardcoded credentials
            // This allows credentials to be loaded from:
            // 1. Environment variables (AWS_ACCESS_KEY_ID, AWS_SECRET_ACCESS_KEY)
            // 2. AWS credentials file (~/.aws/credentials)
            // 3. IAM role for ECS tasks or EC2 instances
            // 4. Fallback to explicit credentials if provided in settings
            if (!string.IsNullOrEmpty(settings.Value.AccessKey) && !string.IsNullOrEmpty(settings.Value.SecretKey))
            {
                var credentials = new BasicAWSCredentials(settings.Value.AccessKey, settings.Value.SecretKey);
                _client = new AmazonComprehendClient(credentials);
            }
            else
            {
                // Use default credential provider chain (environment vars, IAM roles, etc.)
                _client = new AmazonComprehendClient();
            }
        }

        public AmazonComprehendClient Client => _client;
    }
}
