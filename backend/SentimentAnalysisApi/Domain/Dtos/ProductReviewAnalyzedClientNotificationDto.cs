namespace Domain.Dtos
{
    public sealed record ProductReviewAnalyzedClientNotificationDto
    {
        public required string Title { get; init; }
        public required string Description { get; init; }
    }
}
