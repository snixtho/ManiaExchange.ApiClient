using Hawf.Attributes;

namespace ManiaExchange.Api;

/// <summary>
/// API client for Item Exchange.
/// </summary>
[ApiClient("https://item.exchange")]
public class IxApi : MxBase<IxApi>
{
    public IxApi(string userAgent) : base(userAgent)
    {
    }

    /// <summary>
    /// Downloads a user's basket of items in a .zip.
    /// </summary>
    /// <param name="userId">MX UserID</param>
    /// <param name="ignoreDir">false(default): Puts items in their respective directories, true: Ignores directories of items and puts all in the root directory</param>
    /// <returns></returns>
    public Task<Stream> DownloadBasketAsync(long userId, bool ignoreDir = false) =>
        WithUserAgent(MxUserAgent)
            .WithQueryParam("ignDir", ignoreDir)
            .GetStreamAsync("/basket/download/{userID}", userId);
}
