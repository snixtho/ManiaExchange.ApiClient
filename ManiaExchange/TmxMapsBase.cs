using ManiaExchange.Api.Enums;
using ManiaExchange.Api.Models;
using ManiaExchange.Api.Models.Search;

namespace ManiaExchange.Api;

public class TmxMapsBase<T> : MxMapsBase<T> where T : TmxMapsBase<T>
{
    public TmxMapsBase(string userAgent) : base(userAgent)
    {
    }

    /// <summary>
    /// Get a list of MX Leaderboard Seasons.
    /// </summary>
    /// <returns></returns>
    public Task<TmxLeaderboardSeason[]?> GetLeaderboardSeasonsAsync() =>
        WithQueryParam("format", TmxOutputFormat.Json)
            .GetJsonAsync<TmxLeaderboardSeason[]>("/api/leaderboard/getseasons");
    
    /// <summary>
    /// Get replay info based on the ReplayID on MX.
    /// </summary>
    /// <param name="id">MX ReplayID</param>
    /// <returns></returns>
    public Task<TmxReplayInfo?> GetReplayAsync(long id) =>
        GetJsonAsync<TmxReplayInfo>("/api/replays/get_replay_info/{id}", id);
    
    /// <summary>
    /// Get one or multiple User's seasonal / cumulative leaderboard stats.
    /// </summary>
    /// <param name="seasonId">Identifier of the season (see Get LB Seasons method). -1: Cumulative leaderboard</param>
    /// <param name="ids">MX UserIDs</param>
    /// <returns></returns>
    public Task<TmxUserLeaderboardStats[]?> GetUserLeaderboardStatsAsync(int seasonId, params long[] ids) =>
        GetJsonAsync<TmxUserLeaderboardStats[]>("/api/leaderboard/season/{SeasonID}/user/{ids}", seasonId,
                string.Join(',', ids));
    
    /// <summary>
    /// Search through the MX Leaderboard (cumulative / seasonal). The results are paged.
    /// </summary>
    /// <param name="searchOptions">Search parameters</param>
    /// <returns></returns>
    public Task<TmxLeaderboardSearchResult?> SearchLeaderboardAsync(Action<TmxLeaderboardSearchOptions>? searchOptions = null) =>
        WithQueryParam("api", "on")
            .WithQueryParam("format", TmxOutputFormat.Json)
            .WithQueryOptions(searchOptions)
            .GetJsonAsync<TmxLeaderboardSearchResult>("/leaderboard/search");
    
    /// <summary>
    /// Get a list of all submitted replays on a map.
    ///
    /// Note: MX Leaderboards are restricted to 25 records per map.
    /// </summary>
    /// <param name="id">MX TrackID / MapID</param>
    /// <param name="amount">Amount of replays starting from the MX World Record to get (limited to 25)</param>
    /// <returns></returns>
    public Task<TmxReplayInfo[]?> GetMapRecordsAsync(long id, int? amount = null) =>
        WithQueryParam("amount", amount)
            .GetJsonAsync<TmxReplayInfo[]>("/api/replays/get_replays/{id}", id);
}