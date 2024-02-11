namespace DfE.Data.Infrastructure.Persistence.Caching
{
    public interface IOutputCacheProviderFactory
    {
        IOutputCacheProvider GetCacheOutputProvider(string activeCacheKey);
    }
}