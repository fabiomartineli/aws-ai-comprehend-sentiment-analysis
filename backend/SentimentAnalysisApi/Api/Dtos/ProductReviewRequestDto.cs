namespace Api.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public sealed record ProductReviewRequestDto
    {
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Product name must be between 1 and 200 characters")]
        public string ProductName { get; init; }

        [Required(ErrorMessage = "Comment is required")]
        [StringLength(5000, MinimumLength = 1, ErrorMessage = "Comment must be between 1 and 5000 characters")]
        public string Comment { get; init; }

        [Required(ErrorMessage = "User name is required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "User name must be between 1 and 100 characters")]
        public string UserName { get; init; }
    }
}
