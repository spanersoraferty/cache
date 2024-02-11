using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DfE.Data.Infrastructure.Persistence.Caching
{
    public sealed class DefaultOutputCacheHandler : IOutputCacheHandler
    {
        private readonly CacheConfiguration _cacheConfiguration;
        private readonly ICacheKeyFactory _cacheKeyFactory;
        private readonly IOutputCacheProviderFactory _outputCacheProviderFactory;

        public DefaultOutputCacheHandler(
            IOptions<CacheConfiguration> cacheConfiguration,
            ICacheKeyFactory cacheKeyFactor,
            IOutputCacheProviderFactory outputCacheProviderFactory)
        {
            if (cacheConfiguration == null)
            {
                throw new ArgumentNullException(nameof(cacheConfiguration));
            }
            _cacheConfiguration = cacheConfiguration.Value;

            _outputCacheProviderFactory = outputCacheProviderFactory ??
                throw new ArgumentNullException(nameof(outputCacheProviderFactory));

            _cacheKeyFactory = cacheKeyFactor ??
                throw new ArgumentNullException(nameof(cacheKeyFactor));
        }

    }
}
