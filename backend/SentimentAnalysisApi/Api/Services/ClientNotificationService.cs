using Api.Hubs;
using Domain.Dtos;
using Domain.Services;
using Microsoft.AspNetCore.SignalR;

namespace Api.Services
{
    public class ClientNotificationService : IClientNotificationService
    {
        private readonly IHubContext<ProductReviewedHub, IProductReviewedHub> _productReviewedHub;

        public ClientNotificationService(IHubContext<ProductReviewedHub, IProductReviewedHub> productReviewedHub)
        {
            _productReviewedHub = productReviewedHub;
        }

        public async Task ProductReviewedAnalyzeAsync(ProductReviewAnalyzedClientNotificationDto content, CancellationToken cancellationToken)
        {
            await _productReviewedHub.Clients.All.NewCommentAnalyzed(content).ConfigureAwait(false);
        }
    }
}
