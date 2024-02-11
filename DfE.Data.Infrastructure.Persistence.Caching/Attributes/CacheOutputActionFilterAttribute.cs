using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace DfE.Data.Infrastructure.Persistence.Caching.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class CacheOutputActionFilterAttribute : ActionFilterAttribute
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOutputCacheHandler _outputCacheHandler;
        public CacheOutputActionFilterAttribute(
            IHttpContextAccessor httpContextAccessor,
            IOutputCacheHandler outputCacheHandler)
        {
            _httpContextAccessor = httpContextAccessor ??
                throw new ArgumentNullException(nameof(httpContextAccessor));
            
            _outputCacheHandler = outputCacheHandler;
                throw new ArgumentNullException(nameof(outputCacheHandler));
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
           
            #region legacy
            //if (actionContext == null) throw new ArgumentNullException("actionContext");

            //if (!IsCachingAllowed(actionContext, AnonymousOnly)) return;

            //var config = actionContext.Request.GetConfiguration();

            //EnsureCacheTimeQuery();
            //EnsureCache(config, actionContext.Request);

            //var cacheKeyGenerator = config.CacheOutputConfiguration().GetCacheKeyGenerator(actionContext.Request, CacheKeyGenerator);

            //var responseMediaType = GetExpectedMediaType(config, actionContext);
            //actionContext.Request.Properties[CurrentRequestMediaType] = responseMediaType;
            //var cachekey = cacheKeyGenerator.MakeCacheKey(actionContext, responseMediaType, ExcludeQueryStringFromCacheKey);

            //if (!_webApiCache.Contains(cachekey)) return;

            //var responseHeaders = _webApiCache.Get<Dictionary<string, List<string>>>(cachekey + Constants.CustomHeaders);
            //var responseContentHeaders = _webApiCache.Get<Dictionary<string, List<string>>>(cachekey + Constants.CustomContentHeaders);

            //if (actionContext.Request.Headers.IfNoneMatch != null)
            //{
            //    var etag = _webApiCache.Get<string>(cachekey + Constants.EtagKey);
            //    if (etag != null)
            //    {
            //        if (actionContext.Request.Headers.IfNoneMatch.Any(x => x.Tag == etag))
            //        {
            //            var time = CacheTimeQuery.Execute(DateTime.Now);
            //            var quickResponse = actionContext.Request.CreateResponse(HttpStatusCode.NotModified);
            //            if (responseHeaders != null) AddCustomCachedHeaders(quickResponse, responseHeaders, responseContentHeaders);

            //            SetEtag(quickResponse, etag);
            //            ApplyCacheHeaders(quickResponse, time);
            //            actionContext.Response = quickResponse;
            //            return;
            //        }
            //    }
            //}

            //var val = _webApiCache.Get<byte[]>(cachekey);
            //if (val == null) return;

            //var contenttype = _webApiCache.Get<MediaTypeHeaderValue>(cachekey + Constants.ContentTypeKey) ?? responseMediaType;
            //var contentGeneration = _webApiCache.Get<string>(cachekey + Constants.GenerationTimestampKey);

            //DateTimeOffset? contentGenerationTimestamp = null;
            //if (contentGeneration != null)
            //{
            //    if (DateTimeOffset.TryParse(contentGeneration, out DateTimeOffset parsedContentGenerationTimestamp))
            //    {
            //        contentGenerationTimestamp = parsedContentGenerationTimestamp;
            //    }
            //};

            //actionContext.Response = actionContext.Request.CreateResponse();
            //actionContext.Response.Content = new ByteArrayContent(val);

            //actionContext.Response.Content.Headers.ContentType = contenttype;
            //var responseEtag = _webApiCache.Get<string>(cachekey + Constants.EtagKey);
            //if (responseEtag != null) SetEtag(actionContext.Response, responseEtag);

            //if (responseHeaders != null) AddCustomCachedHeaders(actionContext.Response, responseHeaders, responseContentHeaders);

            //var cacheTime = CacheTimeQuery.Execute(DateTime.Now);
            //ApplyCacheHeaders(actionContext.Response, cacheTime, contentGenerationTimestamp);
            #endregion
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            #region legacy
            //    if (actionExecutedContext.ActionContext.Response == null || !actionExecutedContext.ActionContext.Response.IsSuccessStatusCode) return;

            //    if (!IsCachingAllowed(actionExecutedContext.ActionContext, AnonymousOnly)) return;

            //    var actionExecutionTimestamp = DateTimeOffset.Now;
            //    var cacheTime = CacheTimeQuery.Execute(actionExecutionTimestamp.DateTime);
            //    if (cacheTime.AbsoluteExpiration > actionExecutionTimestamp)
            //    {
            //        var httpConfig = actionExecutedContext.Request.GetConfiguration();
            //        var config = httpConfig.CacheOutputConfiguration();
            //        var cacheKeyGenerator = config.GetCacheKeyGenerator(actionExecutedContext.Request, CacheKeyGenerator);

            //        var responseMediaType = actionExecutedContext.Request.Properties[CurrentRequestMediaType] as MediaTypeHeaderValue ?? GetExpectedMediaType(httpConfig, actionExecutedContext.ActionContext);
            //        var cachekey = cacheKeyGenerator.MakeCacheKey(actionExecutedContext.ActionContext, responseMediaType, ExcludeQueryStringFromCacheKey);

            //        if (!string.IsNullOrWhiteSpace(cachekey) && !(_webApiCache.Contains(cachekey)))
            //        {
            //            SetEtag(actionExecutedContext.Response, CreateEtag(actionExecutedContext, cachekey, cacheTime));

            //            var responseContent = actionExecutedContext.Response.Content;

            //            if (responseContent != null)
            //            {
            //                var baseKey = config.MakeBaseCachekey(actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerType.FullName, actionExecutedContext.ActionContext.ActionDescriptor.ActionName);
            //                var contentType = responseContent.Headers.ContentType;
            //                string etag = actionExecutedContext.Response.Headers.ETag.Tag;
            //                //ConfigureAwait false to avoid deadlocks
            //                var content = await responseContent.ReadAsByteArrayAsync().ConfigureAwait(false);

            //                responseContent.Headers.Remove("Content-Length");

            //                _webApiCache.Add(baseKey, string.Empty, cacheTime.AbsoluteExpiration);
            //                _webApiCache.Add(cachekey, content, cacheTime.AbsoluteExpiration, baseKey);


            //                _webApiCache.Add(cachekey + Constants.ContentTypeKey,
            //                                contentType,
            //                                cacheTime.AbsoluteExpiration, baseKey);


            //                _webApiCache.Add(cachekey + Constants.EtagKey,
            //                                etag,
            //                                cacheTime.AbsoluteExpiration, baseKey);

            //                _webApiCache.Add(cachekey + Constants.GenerationTimestampKey,
            //                                actionExecutionTimestamp.ToString(),
            //                                cacheTime.AbsoluteExpiration, baseKey);

            //                if (!String.IsNullOrEmpty(IncludeCustomHeaders))
            //                {
            //                    // convert to dictionary of lists to ensure thread safety if implementation of IEnumerable is changed
            //                    var headers = actionExecutedContext.Response.Headers.Where(h => IncludeCustomHeaders.Contains(h.Key))
            //                        .ToDictionary(x => x.Key, x => x.Value.ToList());

            //                    var contentHeaders = actionExecutedContext.Response.Content.Headers.Where(h => IncludeCustomHeaders.Contains(h.Key))
            //                        .ToDictionary(x => x.Key, x => x.Value.ToList());

            //                    _webApiCache.Add(cachekey + Constants.CustomHeaders,
            //                                    headers,
            //                                    cacheTime.AbsoluteExpiration, baseKey);

            //                    _webApiCache.Add(cachekey + Constants.CustomContentHeaders,
            //                                    contentHeaders,
            //                                    cacheTime.AbsoluteExpiration, baseKey);
            //                }
            //            }
            //        }
            //    }

            //    ApplyCacheHeaders(actionExecutedContext.ActionContext.Response, cacheTime, actionExecutionTimestamp);
            #endregion
        }
    }
}