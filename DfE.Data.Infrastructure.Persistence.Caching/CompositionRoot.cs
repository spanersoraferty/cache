using Microsoft.Extensions.DependencyInjection;

namespace DfE.Data.Infrastructure.Persistence.Caching
{
    public static class CompositionRoot
    {
        public static void AddCacheOutputServices(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services),
                    "A service collection is required to configure the cache output service dependencies.");
            }
        }
    }
}
