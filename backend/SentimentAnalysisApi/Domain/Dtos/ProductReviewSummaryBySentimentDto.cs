using Domain.Types;

namespace Domain.Dtos
{
    public sealed record ProductReviewSummaryBySentimentDto
    {
        public required int Count { get; init; }
        public required ProducteReviewSentimentType Sentiment { get; init; }
    }
}
