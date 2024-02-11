using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DfE.Data.Infrastructure.Persistence.Caching.Core
{
    public interface ICacheKeyFactory
    {
        string MakeCacheKey(string context, MediaTypeHeaderValue mediaType, bool excludeQueryString = false); // probs need to make an ICacheKeyContext type
    }
}
