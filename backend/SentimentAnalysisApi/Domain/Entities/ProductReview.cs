using Domain.Types;

namespace Domain.Entities
{
    public class ProductReview
    {
        public Guid Id { get; init; }
        public string UserName { get; init; }
        public string ProductName { get; init; }
        public string Comment { get; init; }
        public ProducteReviewSentimentType Sentiment { get; set; }
    }
}
