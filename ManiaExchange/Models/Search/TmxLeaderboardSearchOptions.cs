using Hawf.Attributes;
using ManiaExchange.Api.Enums;

namespace ManiaExchange.Api.Models.Search;

public class TmxLeaderboardSearchOptions : TmxSearchOptions
{
    /// <summary>
    /// Search mode - 0: seasonal (default), 1: cumulative
    /// </summary>
    [QueryProperty("mode", true)]
    public TmxLeaderboardSearchMode? Mode { get; set; }
    /// <summary>
    /// Season to search (see Get Leaderboard Seasons method) - defaults at current ongoing season (only mode=0)
    /// </summary>
    [QueryProperty("seasonid")]
    public int? SeasonId { get; set; }
    /// <summary>
    /// MX Username
    /// </summary>
    [QueryProperty("username")]
    public string? Username { get; set; }
    /// <summary>
    /// Primary Order (default: 2)
    /// </summary>
    [QueryProperty("priord", true)]
    public TmxLeaderboardSearchOrder? Priord { get; set; }
    /// <summary>
    /// Secondary Order
    /// </summary>
    [QueryProperty("secord", true)]
    public TmxLeaderboardSearchOrder? Secord { get; set; }
}