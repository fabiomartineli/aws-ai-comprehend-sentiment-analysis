using Domain.Commands;
using Domain.Commands.Base;
using Domain.Repositories;
using Domain.Services;
using Domain.Types;
using Infra.AI.SentimentAnalysis;

namespace Application.Commands
{
    public class AnalyzeProductReviewHandler : ICommandHandler<AnalyzeProductReviewCommand, bool>
    {
        private readonly IProductReviewRepository _productReviewRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISentimentAnalysisService _sentimentAnalysisService;
        private readonly IClientNotificationService _notificationService;
        public AnalyzeProductReviewHandler(IProductReviewRepository productReviewRepository,
            IUnitOfWork unitOfWork,
            ISentimentAnalysisService sentimentAnalysisService,
            IClientNotificationService notificationService)
        {
            _productReviewRepository = productReviewRepository;
            _unitOfWork = unitOfWork;
            _sentimentAnalysisService = sentimentAnalysisService;
            _notificationService = notificationService;
        }

        public async Task<bool> ExecuteAsync(AnalyzeProductReviewCommand command, CancellationToken cancellationToken)
        {
            var review = await _productReviewRepository.FindAsync(command.Review.Id, cancellationToken);
            
            if (review == null)
            {
                throw new InvalidOperationException($"Product review with ID {command.Review.Id} not found");
            }

            var sentiment = await _sentimentAnalysisService.ExecuteAsync(command.Review.Comment, cancellationToken);
            
            review.Sentiment = GetDomainType(sentiment);

            await _unitOfWork.StartTransactionAsync(cancellationToken);
            await _productReviewRepository.UpdateAsync(review, cancellationToken);
            await _unitOfWork.CommitTransactionAsync(cancellationToken);

            await _notificationService.ProductReviewedAnalyzeAsync(new()
            {
               Title = "Nova análise recebida",
               Description = $"O produto {review.ProductName} recebeu uma atualização"
            }, cancellationToken);

            return true;
        }

        private static ProductReviewSentimentType GetDomainType(SentimentAnalysisType sentimentAnalysisType)
            => sentimentAnalysisType switch 
            {
                SentimentAnalysisType.NotIdentified => ProductReviewSentimentType.NotIdentified,
                SentimentAnalysisType.Neutral => ProductReviewSentimentType.Neutral,
                SentimentAnalysisType.Positive => ProductReviewSentimentType.Positive,
                SentimentAnalysisType.Negative => ProductReviewSentimentType.Negative,
                SentimentAnalysisType.Mixed => ProductReviewSentimentType.Mixed,
                _ => ProductReviewSentimentType.NotIdentified
            };
    }
}
