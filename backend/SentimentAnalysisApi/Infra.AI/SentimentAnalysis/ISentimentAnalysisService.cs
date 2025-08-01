namespace Infra.AI.SentimentAnalysis
{

    public interface ISentimentAnalysisService
    {
        Task<SentimentAnalysisType> ExecuteAsync(string text, CancellationToken cancellationToken);
    }
}
