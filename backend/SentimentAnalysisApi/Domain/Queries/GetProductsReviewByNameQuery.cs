namespace Domain.Queries
{
    public sealed record GetProductsReviewByNameQuery
    {
        public required string ProductName { get; init; }

        public sealed record GetProductsReviewByNameQueryResponse
        {
            public required string ProductName { get; init; }
            public required string Comment { get; init; }
            public required string Sentiment { get; init; }
        }
    }
}
