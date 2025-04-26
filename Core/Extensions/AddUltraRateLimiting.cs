using Microsoft.Extensions.DependencyInjection;
using UltraNet.Core.Interfaces.RateLimiting;
using UltraNet.Modules.RateLimiting;
using UltraNet.Modules.RateLimiting.Strategies;

namespace UltraNet.Core.Extensions;
public static class RateLimitingServiceCollectionExtensions
{
    public static IServiceCollection AddUltraRateLimiting(this IServiceCollection services)
    {
        services.AddScoped<IRateLimitStrategy, InMemoryTokenBucket>();
        services.AddScoped<IRateLimiter, RateLimiter>();
        return services;
    }
}
