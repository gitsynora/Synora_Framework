using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UltraNet.Core.Interfaces.Caching;
using UltraNet.Modules.Caching;
using UltraNet.Modules.Caching.Factory;
using UltraNet.Modules.Caching.Providers;

namespace UltraNet.Core.Extensions;
public static class CachingServiceCollectionExtensions
{
    public static IServiceCollection AddUltraCaching(this IServiceCollection services, IConfiguration configuration)
    {
        var cacheType = configuration["Cache:Type"]?.ToLower() ?? "memory";

        services.AddMemoryCache();
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration["Redis:Configuration"];
            options.InstanceName = configuration["Redis:InstanceName"];
        });

        services.AddScoped<MemoryCacheProvider>();
        services.AddScoped<RedisCacheProvider>();
        services.AddScoped<ICacheProviderFactory, CacheProviderFactory>();
        services.AddScoped<ICacheService, CacheService>();

        return services;
    }
}