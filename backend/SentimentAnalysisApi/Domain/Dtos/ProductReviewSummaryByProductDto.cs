using Domain.Types;

namespace Domain.Dtos
{
    public sealed record ProductReviewSummaryByProductDto
    {
        public required string ProductName { get; init; }
        public required ProductReviewSentimentType Sentiment { get; init; }
        public required int Count { get; init; }
    }
}
