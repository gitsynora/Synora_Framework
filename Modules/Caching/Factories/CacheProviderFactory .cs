using UltraNet.Core.Interfaces.Caching;
using UltraNet.Modules.Caching.Providers;

namespace UltraNet.Modules.Caching.Factory
{
    public class CacheProviderFactory : ICacheProviderFactory
    {
        private readonly MemoryCacheProvider _memory;
        private readonly RedisCacheProvider _redis;

        public CacheProviderFactory(MemoryCacheProvider memory, RedisCacheProvider redis)
        {
            _memory = memory;
            _redis = redis;
        }

        public ICacheProvider GetProvider(string name)
        {
            return name.ToLower() switch
            {
                "memory" => _memory,
                "redis" => _redis,
                _ => _memory
            };
        }
    }
}
