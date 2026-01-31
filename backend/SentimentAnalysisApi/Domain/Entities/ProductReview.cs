using Domain.Types;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ProductReview
    {
        public Guid Id { get; init; }

        [Required]
        [MaxLength(100)]
        public string UserName { get; init; }

        [Required]
        [MaxLength(200)]
        public string ProductName { get; init; }

        [Required]
        [MaxLength(5000)]
        public string Comment { get; init; }

        public ProductReviewSentimentType Sentiment { get; set; }
    }
}
