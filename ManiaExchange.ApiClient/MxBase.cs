using Hawf.Client;
using ManiaExchange.ApiClient.Models;

namespace ManiaExchange.ApiClient;

public class MxBase<T> : ApiBase<T> where T : MxBase<T>
{
    protected TimeSpan CacheTime = TimeSpan.Zero;
    
    protected MxBase(string userAgent)
    {
        Configure(options => options.DefaultUserAgent = userAgent);
    }

    /// <summary>
    /// Disable the cache for the next requests.
    /// </summary>
    /// <returns></returns>
    public T DisableCache()
    {
        CacheTime = TimeSpan.Zero;
        return (T) this;
    }

    /// <summary>
    /// Set the amount of time to cache a GET request for.
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    public T SetCacheTime(TimeSpan time)
    {
        CacheTime = time;
        return (T) this;
    }

    /// <summary>
    /// Get an array of all current map & mappack / item & set tags.
    /// </summary>
    /// <param name="cancelToken"></param>
    /// <returns></returns>
    public Task<TmxTag[]?> GetTagsAsync(CancellationToken cancelToken = default) =>
        WithCancelToken(cancelToken)
            .CacheResponseFor(CacheTime)
            .GetJsonAsync<TmxTag[]>("/api/tags/gettags");
}