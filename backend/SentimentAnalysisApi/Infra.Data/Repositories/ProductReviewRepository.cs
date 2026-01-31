using Domain.Dtos;
using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infra.Data.Repositories
{
    public class ProductReviewRepository : IProductReviewRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ProductReviewRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task AddAsync(ProductReview productReview, CancellationToken cancellationToken)
        {
            await _databaseContext.Set<ProductReview>().AddAsync(productReview, cancellationToken);
        }

        public Task UpdateAsync(ProductReview productReview, CancellationToken _)
        {
            _databaseContext.Set<ProductReview>().Update(productReview);

            return Task.CompletedTask;
        }

        public async Task<ProductReview> FindAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _databaseContext.Set<ProductReview>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<ProductReview>> FindByProductAsync(string productName, CancellationToken cancellationToken)
        {
            var param = productName ?? string.Empty;

            return await _databaseContext.Set<ProductReview>()
                .Where(x => x.ProductName.ToLower().Contains(param.ToLower()))
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<ProductReviewSummaryBySentimentDto>> SummaryBySentimentAsync(CancellationToken cancellationToken)
        {
            return await _databaseContext.Set<ProductReview>()
                .GroupBy(x => x.Sentiment)
                .Select(x => new ProductReviewSummaryBySentimentDto()
                {
                    Count = x.Count(),
                    Sentiment = x.Key
                })
                .ToListAsync(cancellationToken);
        }

        // Optimized query that retrieves top 3 positive and negative products in a single database call
        public async Task<IEnumerable<ProductReviewSummaryByProductDto>> SummaryByProductAsync(CancellationToken cancellationToken)
        {
            var results = await _databaseContext.Set<ProductReview>()
                .Where(x => x.Sentiment == Domain.Types.ProductReviewSentimentType.Negative || 
                           x.Sentiment == Domain.Types.ProductReviewSentimentType.Positive)
                .GroupBy(x => new { x.ProductName, x.Sentiment })
                .Select(x => new 
                {
                    x.Key.ProductName,
                    x.Key.Sentiment,
                    Count = x.Count()
                })
                .ToListAsync(cancellationToken);

            var topNegative = results
                .Where(x => x.Sentiment == Domain.Types.ProductReviewSentimentType.Negative)
                .OrderByDescending(x => x.Count)
                .Take(3)
                .Select(x => new ProductReviewSummaryByProductDto
                {
                    ProductName = x.ProductName,
                    Sentiment = x.Sentiment,
                    Count = x.Count
                });

            var topPositive = results
                .Where(x => x.Sentiment == Domain.Types.ProductReviewSentimentType.Positive)
                .OrderByDescending(x => x.Count)
                .Take(3)
                .Select(x => new ProductReviewSummaryByProductDto
                {
                    ProductName = x.ProductName,
                    Sentiment = x.Sentiment,
                    Count = x.Count
                });

            return [.. topNegative, .. topPositive];
        }
    }
}
