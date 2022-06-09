using Hawf.Client;
using ManiaExchange.Api.Models;

namespace ManiaExchange.Api;

public class MxBase<T> : ApiBase<T> where T : MxBase<T>
{
    protected MxBase(string userAgent)
    {
        Configure(options => options.DefaultUserAgent = userAgent);
    }
    
    /// <summary>
    /// Get an array of all current map & mappack / item & set tags.
    /// </summary>
    /// <returns></returns>
    public Task<TmxTag[]?> GetTagsAsync() =>
        GetJsonAsync<TmxTag[]>("/api/tags/gettags");
}