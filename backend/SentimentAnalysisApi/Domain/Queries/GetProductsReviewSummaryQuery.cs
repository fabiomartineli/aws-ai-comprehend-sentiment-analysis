using Domain.Types;

namespace Domain.Queries
{
    public sealed record GetProductsReviewSummaryQuery
    {
        public sealed record GetProductsReviewSummaryQueryResponse
        {
            public required GetProductsReviewSummarySentimentResponse Sentiment { get; init; }
            public required IEnumerable<GetProductsReviewSummaryProductResponse> TopNegativeProducts { get; init; }
            public required IEnumerable<GetProductsReviewSummaryProductResponse> TopPositiveProducts { get; init; }
        }

        public sealed record GetProductsReviewSummarySentimentResponse
        {
            public required int TotalNegativeSentiment { get; init; }
            public required int TotalPositiveSentiment { get; init; }
            public required int TotalNeutralSentiment { get; init; }
            public required int TotalInProcessing { get; init; }
            public required int Total { get; init; }
        }

        public sealed record GetProductsReviewSummaryProductResponse
        {
            public required string ProductName { get; init; }
            public required int Count { get; init; }
        }
    }
}
