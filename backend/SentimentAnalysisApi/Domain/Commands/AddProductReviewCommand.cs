namespace Domain.Commands
{
    public sealed record AddProductReviewCommand
    {
        public required string UserName { get; init; }
        public required string ProductName { get; init; }
        public required string Comment { get; init; }
    }
}
