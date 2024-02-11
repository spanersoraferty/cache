using System.Runtime.Caching;

namespace DfE.Data.Infrastructure.Persistence.Caching.Core
{
    public sealed class DefaultMemoryCacheProvider : IOutputCacheProvider
    {
        private static readonly MemoryCache _cache = MemoryCache.Default;

        public IEnumerable<string> GetAllCacheKeys => _cache.Select(cachedItem => cachedItem.Key);

        public void AddObjectToCache<TObject>(string key, TObject @object, DateTimeOffset expiration) where TObject : class
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            lock (_cache)
            {
                _cache.Add(key, @object, new CacheItemPolicy
                {
                    AbsoluteExpiration = expiration
                });
            }
        }

        public bool CacheContains(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            return _cache.Contains(key);
        }

        public TObject GetCachedObject<TObject>(string key) where TObject : class
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            return (_cache.Get(key) is not TObject @object) ?
                throw new ArgumentOutOfRangeException(key, $"Unable to derive object from memory cache with key {key}.") : @object;
        }

        public void RemoveObjectFromCache(string key)
        {
            lock (_cache)
            {
                _cache.Remove(key);
            }
        }
    }
}