using Hawf.Attributes;

namespace ManiaExchange.Api;

/// <summary>
/// API client for TrackMania 2 Exchange.
/// </summary>
[ApiClient("https://tm.mania.exchange")]
public class TmxTm2Api : MxMapsBase<TmxTm2Api>
{
    public TmxTm2Api(string userAgent) : base(userAgent)
    {
        
    }
}
