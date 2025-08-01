using Domain.Repositories;
using Infra.Data.Base;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Data
{
    public static class IoCExtension
    {
        public static IServiceCollection AddIoCData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<DatabaseContext>(opt =>
            {
                opt.UseNpgsql(configuration.GetConnectionString("Postgres"));
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                opt.EnableDetailedErrors();
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductReviewRepository, ProductReviewRepository>();

            return services;
        }
    }
}
