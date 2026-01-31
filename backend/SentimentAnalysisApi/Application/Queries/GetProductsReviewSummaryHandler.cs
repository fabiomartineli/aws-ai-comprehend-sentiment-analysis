using Domain.Queries;
using Domain.Queries.Base;
using Domain.Repositories;
using Domain.Types;
using static Domain.Queries.GetProductsReviewSummaryQuery;

namespace Application.Queries
{
    public class GetProductsReviewSummaryHandler : IQueryHandler<GetProductsReviewSummaryQuery, GetProductsReviewSummaryQueryResponse>
    {
        private readonly IProductReviewRepository _repository;

        public GetProductsReviewSummaryHandler(IProductReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetProductsReviewSummaryQueryResponse> ExecuteAsync(GetProductsReviewSummaryQuery query, CancellationToken cancellationToken)
        {
            var sentimentSummary = await _repository.SummaryBySentimentAsync(cancellationToken);
            var productsSummary = await _repository.SummaryByProductAsync(cancellationToken);

            ProductReviewSentimentType[] neutralSentiments = [ProductReviewSentimentType.Neutral, ProductReviewSentimentType.Mixed];

            return new()
            {
                Sentiment = new()
                {
                    TotalNegativeSentiment = sentimentSummary.FirstOrDefault(x => x.Sentiment == ProductReviewSentimentType.Negative)?.Count ?? 0,
                    TotalPositiveSentiment = sentimentSummary.FirstOrDefault(x => x.Sentiment == ProductReviewSentimentType.Positive)?.Count ?? 0,
                    TotalInProcessing = sentimentSummary.FirstOrDefault(x => x.Sentiment == ProductReviewSentimentType.NotIdentified)?.Count ?? 0,
                    TotalNeutralSentiment = sentimentSummary.FirstOrDefault(x => neutralSentiments.Contains(x.Sentiment))?.Count ?? 0,
                    Total = sentimentSummary.Sum(x => x.Count)
                },
                TopNegativeProducts = productsSummary
                        .Where(x => x.Sentiment == ProductReviewSentimentType.Negative)
                        .Select(x => new GetProductsReviewSummaryProductResponse() 
                        {
                            ProductName = x.ProductName,
                            Count = x.Count,
                        }),
                TopPositiveProducts = productsSummary
                        .Where(x => x.Sentiment == ProductReviewSentimentType.Positive)
                        .Select(x => new GetProductsReviewSummaryProductResponse()
                        {
                            ProductName = x.ProductName,
                            Count = x.Count,
                        }),
            };
        }
    }
}
