namespace Api.Dtos
{
    public sealed record ProductReviewRequestDto
    {
        public string ProductName { get; init; }
        public string Comment { get; init; }
        public string UserName { get; init; }
    }
}
