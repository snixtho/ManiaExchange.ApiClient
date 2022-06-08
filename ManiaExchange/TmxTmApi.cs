using Hawf.Attributes;

namespace ManiaExchange.Api;

/// <summary>
/// API client for TrackMania 2020 Exchange.
/// </summary>
[ApiClient("https://trackmania.exchange")]
public class TmxTmApi : TmxMapsBase<TmxTmApi>
{
    public TmxTmApi(string userAgent) : base(userAgent)
    {
    }
}