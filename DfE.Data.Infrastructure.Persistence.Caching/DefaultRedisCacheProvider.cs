using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DfE.Data.Infrastructure.Persistence.Caching.Core
{
    public sealed class DefaultRedisCacheProvider : IOutputCacheProvider
    {
        public IEnumerable<string> GetAllCacheKeys => throw new NotImplementedException();

        public void AddObjectToCache<TObject>(string key, TObject @object, DateTimeOffset expiration) where TObject : class
        {
            throw new NotImplementedException();
        }

        public bool CacheContains(string key)
        {
            throw new NotImplementedException();
        }

        public TObject GetCachedObject<TObject>(string key) where TObject : class
        {
            throw new NotImplementedException();
        }

        public void RemoveObjectFromCache(string key)
        {
            throw new NotImplementedException();
        }
    }
}
