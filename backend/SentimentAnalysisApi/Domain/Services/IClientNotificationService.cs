using Domain.Dtos;

namespace Domain.Services
{
    public interface IClientNotificationService
    {
        Task ProductReviewedAnalyzeAsync(ProductReviewAnalyzedClientNotificationDto content, CancellationToken cancellationToken);
    }
}
