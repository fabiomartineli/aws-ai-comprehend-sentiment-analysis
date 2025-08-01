using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Table_ProductReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product_review",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: true),
                    product_name = table.Column<string>(type: "text", nullable: true),
                    comment = table.Column<string>(type: "text", nullable: true),
                    sentiment = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_review", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_review_product_name",
                table: "product_review",
                column: "product_name");

            migrationBuilder.CreateIndex(
                name: "IX_product_review_user_name_product_name",
                table: "product_review",
                columns: new[] { "user_name", "product_name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_review");
        }
    }
}
