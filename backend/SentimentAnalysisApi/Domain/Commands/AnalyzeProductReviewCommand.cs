using Domain.Entities;

namespace Domain.Commands
{
    public sealed record AnalyzeProductReviewCommand
    {
        public required ProductReview Review { get; init; }
    }
}
