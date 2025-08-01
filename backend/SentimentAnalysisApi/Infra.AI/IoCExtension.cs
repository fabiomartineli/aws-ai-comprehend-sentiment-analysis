using Infra.AI.Clients;
using Infra.AI.SentimentAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.AI
{
    public static class IoCExtension
    {
        public static IServiceCollection AddIoCAi(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ComprehendClientSettings>(configuration.GetSection(ComprehendClientSettings.SectionName));
            services.AddSingleton<IComprehendClient, ComprehendClient>();
            services.AddSingleton<ISentimentAnalysisService, SentimentAnalysisService>();

            return services;
        }
    }
}
