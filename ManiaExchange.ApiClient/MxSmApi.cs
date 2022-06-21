using Hawf.Attributes;

namespace ManiaExchange.ApiClient;

/// <summary>
/// API client for ShootMania Exchange.
/// </summary>
[ApiClient("https://sm.mania.exchange")]
public class MxSmApi : MxMapsBase<MxSmApi>
{
    public MxSmApi(string userAgent) : base(userAgent)
    {
    }
}