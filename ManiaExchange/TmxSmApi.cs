using Hawf.Attributes;

namespace ManiaExchange.Api;

/// <summary>
/// API client for ShootMania Exchange.
/// </summary>
[ApiClient("https://sm.mania.exchange")]
public class TmxSmApi : MxMapsBase<TmxSmApi>
{
    public TmxSmApi(string userAgent) : base(userAgent)
    {
    }
}