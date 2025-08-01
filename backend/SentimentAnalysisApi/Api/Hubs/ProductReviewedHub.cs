using Domain.Dtos;
using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs
{
    public interface IProductReviewedHub
    {
        Task NewCommentAnalyzed(ProductReviewAnalyzedClientNotificationDto content);
    }

    public class ProductReviewedHub : Hub<IProductReviewedHub>
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
