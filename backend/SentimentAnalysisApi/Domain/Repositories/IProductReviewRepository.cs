using Domain.Dtos;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProductReviewRepository
    {
        Task AddAsync(ProductReview productReview, CancellationToken cancellationToken);
        Task UpdateAsync(ProductReview productReview, CancellationToken cancellationToken);
        Task<IEnumerable<ProductReview>> FindByProductAsync(string productName, CancellationToken cancellationToken);
        Task<ProductReview> FindAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<ProductReviewSummaryBySentimentDto>> SummaryBySentimentAsync(CancellationToken cancellationToken);
        Task<IEnumerable<ProductReviewSummaryByProductDto>> SummaryByProductAsync(CancellationToken cancellationToken);
    }
}
