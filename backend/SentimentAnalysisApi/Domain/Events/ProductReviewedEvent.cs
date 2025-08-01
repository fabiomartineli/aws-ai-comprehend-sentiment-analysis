using Domain.Entities;
using Domain.Events.Base;

namespace Domain.Events
{
    public sealed record ProductReviewedEvent : IDomainEvent
    {
        public required ProductReview Review { get; init; }
    }
}
