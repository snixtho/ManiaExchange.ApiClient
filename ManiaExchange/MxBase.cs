using Hawf.Client;
using ManiaExchange.Api.Models;

namespace ManiaExchange.Api;

public class MxBase<T> : ApiBase<T> where T : MxBase<T>
{
    protected TimeSpan CacheTime = TimeSpan.Zero;
    
    protected MxBase(string userAgent)
    {
        Configure(options => options.DefaultUserAgent = userAgent);
    }

    public T UseCache(bool enable = true)
    {
        if (!enable)
            CacheTime = TimeSpan.Zero;
        return (T) this;
    }

    public T SetCacheTime(TimeSpan time)
    {
        CacheTime = time;
        return (T) this;
    }
    
    /// <summary>
    /// Get an array of all current map & mappack / item & set tags.
    /// </summary>
    /// <returns></returns>
    public Task<TmxTag[]?> GetTagsAsync() =>
        CacheResponseFor(CacheTime)
            .GetJsonAsync<TmxTag[]>("/api/tags/gettags");
}