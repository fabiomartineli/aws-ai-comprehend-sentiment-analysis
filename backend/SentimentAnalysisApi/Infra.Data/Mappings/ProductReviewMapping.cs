using Domain.Entities;
using Domain.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings
{
    public class ProductReviewMapping : IEntityTypeConfiguration<ProductReview>
    {
        public void Configure(EntityTypeBuilder<ProductReview> builder)
        {
            builder.ToTable("product_review");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.ProductName);
            builder.HasIndex(x => new { x.UserName, x.ProductName }).IsUnique();
            builder.Property(x => x.UserName).HasColumnName("user_name").IsRequired().HasMaxLength(100);
            builder.Property(x => x.ProductName).HasColumnName("product_name").IsRequired().HasMaxLength(200);
            builder.Property(x => x.Comment).HasColumnName("comment").IsRequired().HasMaxLength(5000);
            builder.Property(x => x.Sentiment)
                .HasColumnName("sentiment")
                .HasConversion(valueFromCode => valueFromCode.ToString(),
                                valueFromDataBase => Enum.Parse<ProductReviewSentimentType>(valueFromDataBase));
        }
    }
}
