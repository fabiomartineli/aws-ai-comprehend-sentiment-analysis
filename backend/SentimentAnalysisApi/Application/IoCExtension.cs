using Application.Commands;
using Application.Queries;
using Domain.Commands;
using Domain.Commands.Base;
using Domain.Queries.Base;
using Domain.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain.Events.Base;
using Domain.Events;
using Application.Events;
using static Domain.Queries.GetProductsReviewSummaryQuery;
using static Domain.Queries.GetProductsReviewByNameQuery;

namespace Application
{
    public static class IoCExtension
    {
        public static IServiceCollection AddIoCApplication(this IServiceCollection services, IConfiguration _)
        {
            services.AddScoped<IDomainEventHandler<ProductReviewedEvent>, ProductReviewedHandler>();
            services.AddScoped<ICommandHandler<AddProductReviewCommand, bool>, AddProductReviewHandler>();
            services.AddScoped<ICommandHandler<AnalyzeProductReviewCommand, bool>, AnalyzeProductReviewHandler>();
            services.AddScoped<IQueryHandler<GetProductsReviewByNameQuery, IEnumerable<GetProductsReviewByNameQueryResponse>>, GetProductsReviewByNameHandler>();
            services.AddScoped<IQueryHandler<GetProductsReviewSummaryQuery, GetProductsReviewSummaryQueryResponse>, GetProductsReviewSummaryHandler>();

            return services;
        }
    }
}
