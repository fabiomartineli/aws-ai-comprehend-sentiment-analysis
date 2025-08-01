using Amazon.Comprehend;

namespace Infra.AI.Clients
{
    internal interface IComprehendClient
    {
        AmazonComprehendClient Client { get; }
    }
}
