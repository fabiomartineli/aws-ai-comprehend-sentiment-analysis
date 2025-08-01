using Domain.Commands;
using Domain.Commands.Base;
using Domain.Events.Base;
using Domain.Events;
using Domain.Repositories;

namespace Application.Commands
{
    public class AddProductReviewHandler : ICommandHandler<AddProductReviewCommand, bool>
    {
        private readonly IProductReviewRepository _productReviewRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainEventHandler<ProductReviewedEvent> _eventHandler;

        public AddProductReviewHandler(IProductReviewRepository productReviewRepository,
            IUnitOfWork unitOfWork,
            IDomainEventHandler<ProductReviewedEvent> eventHandler)
        {
            _productReviewRepository = productReviewRepository;
            _unitOfWork = unitOfWork;
            _eventHandler = eventHandler;
        }

        public async Task<bool> ExecuteAsync(AddProductReviewCommand command, CancellationToken cancellationToken)
        {
            var review = new Domain.Entities.ProductReview
            {
                Id = Guid.CreateVersion7(),
                Comment = command.Comment,
                ProductName = command.ProductName,
            };

            await _unitOfWork.StartTransactionAsync(cancellationToken);
            await _productReviewRepository.AddAsync(review, cancellationToken);
            await _unitOfWork.CommitTransactionAsync(cancellationToken);

            await _eventHandler.ExecuteAsync(new ProductReviewedEvent
            {
                Review = review,
            }, cancellationToken);

            return true;
        }
    }
}
