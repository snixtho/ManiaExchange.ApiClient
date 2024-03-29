﻿using Hawf.Attributes;

namespace ManiaExchange.ApiClient;

/// <summary>
/// API client for TrackMania 2020 Exchange.
/// </summary>
[ApiClient("https://trackmania.exchange")]
public class MxTmApi : TmxMapsBase<MxTmApi>
{
    public MxTmApi(string userAgent) : base(userAgent)
    {
    }
}