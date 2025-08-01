using Domain.Queries;
using Domain.Queries.Base;
using Domain.Repositories;
using static Domain.Queries.GetProductsReviewByNameQuery;

namespace Application.Queries
{
    public class GetProductsReviewByNameHandler : IQueryHandler<GetProductsReviewByNameQuery, IEnumerable<GetProductsReviewByNameQueryResponse>>
    {
        private readonly IProductReviewRepository _repository;

        public GetProductsReviewByNameHandler(IProductReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetProductsReviewByNameQueryResponse>> ExecuteAsync(GetProductsReviewByNameQuery query, CancellationToken cancellationToken)
        {
            var reviews = await _repository.FindByProductAsync(query.ProductName, cancellationToken);

            return reviews.Select(x => new GetProductsReviewByNameQueryResponse()
            {
                Comment = x.Comment,
                ProductName = x.ProductName,
                Sentiment = x.Sentiment.ToString()
            });
        }
    }
}
