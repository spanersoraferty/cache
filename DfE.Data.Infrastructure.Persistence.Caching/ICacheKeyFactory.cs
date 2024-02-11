using System.Net.Http.Headers;

namespace DfE.Data.Infrastructure.Persistence.Caching
{
    public interface ICacheKeyFactory
    {
        string MakeCacheKey(string context, MediaTypeHeaderValue mediaType, bool excludeQueryString = false); // probs need to make an ICacheKeyContext type
    }
}
