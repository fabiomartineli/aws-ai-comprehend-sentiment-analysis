using Api.Dtos;
using Domain.Commands;
using Domain.Commands.Base;
using Domain.Queries;
using Domain.Queries.Base;
using Microsoft.AspNetCore.Mvc;
using static Domain.Queries.GetProductsReviewByNameQuery;
using static Domain.Queries.GetProductsReviewSummaryQuery;

namespace Api.Controllers
{
    /// <summary>
    /// Controller for managing product reviews and sentiment analysis
    /// </summary>
    [ApiController]
    public class ProductReviewController : ControllerBase
    {
        /// <summary>
        /// Submits a new product review for sentiment analysis
        /// </summary>
        /// <param name="request">Product review details including product name, comment, and user name</param>
        /// <param name="handler">Command handler for processing the review</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>OK if successful, BadRequest if validation fails, 500 if an error occurs</returns>
        [HttpPost("/products:review")]
        public async Task<IActionResult> Review([FromBody] ProductReviewRequestDto request,
            [FromServices] ICommandHandler<AddProductReviewCommand, bool> handler,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var command = new AddProductReviewCommand
                {
                    Comment = request.Comment,
                    ProductName = request.ProductName,
                    UserName = request.UserName
                };

                await handler.ExecuteAsync(command, cancellationToken);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while processing your request", details = ex.Message });
            }
        }


        /// <summary>
        /// Retrieves product reviews filtered by product name
        /// </summary>
        /// <param name="productName">Optional product name to filter reviews</param>
        /// <param name="handler">Query handler for retrieving reviews</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of reviews matching the product name</returns>
        [HttpGet("/products:review")]
        public async Task<IActionResult> Review([FromQuery(Name = "product-name")] string productName,
            [FromServices] IQueryHandler<GetProductsReviewByNameQuery, IEnumerable<GetProductsReviewByNameQueryResponse>> handler,
            CancellationToken cancellationToken)
        {
            try
            {
                var command = new GetProductsReviewByNameQuery
                {
                    ProductName = productName,
                };

                var result = await handler.ExecuteAsync(command, cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while retrieving reviews", details = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves a summary of product reviews including sentiment counts and top products
        /// </summary>
        /// <param name="handler">Query handler for retrieving summary data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Summary statistics including total reviews by sentiment and top positive/negative products</returns>
        [HttpGet("/products:review-summary")]
        public async Task<IActionResult> ReviewSummary([FromServices] IQueryHandler<GetProductsReviewSummaryQuery, GetProductsReviewSummaryQueryResponse> handler,
           CancellationToken cancellationToken)
        {
            try
            {
                var result = await handler.ExecuteAsync(new(), cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while retrieving summary", details = ex.Message });
            }
        }
    }
}
