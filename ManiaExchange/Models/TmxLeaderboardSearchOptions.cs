using Hawf.Attributes;
using ManiaExchange.Api.Enums;

namespace ManiaExchange.Api.Models;

public class TmxLeaderboardSearchOptions : TmxSearchOptions
{
    [QueryProperty("mode", true)]
    public TmxLeaderboardSearchMode? Mode { get; set; }
    [QueryProperty("seasonid")]
    public int? SeasonId { get; set; }
    [QueryProperty("username")]
    public string? Username { get; set; }
    [QueryProperty("priord", true)]
    public TmxLeaderboardSearchOrder? Priord { get; set; }
    [QueryProperty("secord", true)]
    public TmxLeaderboardSearchOrder? Secord { get; set; }
}