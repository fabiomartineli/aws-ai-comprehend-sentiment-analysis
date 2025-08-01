using Infra.AI.Clients;

namespace Infra.AI.SentimentAnalysis
{
    internal class SentimentAnalysisService : ISentimentAnalysisService
    {
        private readonly IComprehendClient _client;

        public SentimentAnalysisService(IComprehendClient client)
        {
            _client = client;
        }

        public async Task<SentimentAnalysisType> ExecuteAsync(string text, CancellationToken cancellationToken)
        {
            var result = await _client.Client.DetectSentimentAsync(new()
            {
                LanguageCode = "pt",
                Text = text
            }, cancellationToken);

            Enum.TryParse<SentimentAnalysisType>(result.Sentiment, true, out var sentiment);

            return sentiment;
        }
    }
}
