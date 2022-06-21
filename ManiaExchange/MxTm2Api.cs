using Hawf.Attributes;

namespace ManiaExchange.Api;

/// <summary>
/// API client for TrackMania 2 Exchange.
/// </summary>
[ApiClient("https://tm.mania.exchange")]
public class MxTm2Api : MxMapsBase<MxTm2Api>
{
    public MxTm2Api(string userAgent) : base(userAgent)
    {
        
    }
}
