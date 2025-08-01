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
    [ApiController]
    public class ProductReviewController : ControllerBase
    {
        [HttpPost("/products:review")]
        public async Task<IActionResult> Review([FromBody] ProductReviewRequestDto request,
            [FromServices] ICommandHandler<AddProductReviewCommand, bool> handler,
            CancellationToken cancellationToken)
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


        [HttpGet("/products:review")]
        public async Task<IActionResult> Review([FromQuery(Name = "product-name")] string productName,
            [FromServices] IQueryHandler<GetProductsReviewByNameQuery, IEnumerable<GetProductsReviewByNameQueryResponse>> handler,
            CancellationToken cancellationToken)
        {
            var command = new GetProductsReviewByNameQuery
            {
                ProductName = productName,
            };

            var result = await handler.ExecuteAsync(command, cancellationToken);

            return Ok(result);
        }

        [HttpGet("/products:review-summary")]
        public async Task<IActionResult> ReviewSummary([FromServices] IQueryHandler<GetProductsReviewSummaryQuery, GetProductsReviewSummaryQueryResponse> handler,
           CancellationToken cancellationToken)
        {
            var result = await handler.ExecuteAsync(new(), cancellationToken);

            return Ok(result);
        }
    }
}
