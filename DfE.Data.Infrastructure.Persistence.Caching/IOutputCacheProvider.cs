namespace DfE.Data.Infrastructure.Persistence.Caching
{
    public interface IOutputCacheProvider
    {
        TObject GetCachedObject<TObject>(string key) where TObject : class;
        void AddObjectToCache<TObject>(string key, TObject @object, DateTimeOffset expiration) where TObject : class;
        void RemoveObjectFromCache(string key);
        bool CacheContains(string key);
        IEnumerable<string> GetAllCacheKeys { get; }
    }
}