using Hawf.Attributes;
using Hawf.Client;
using ManiaExchange.Api.Api.Models;
using ManiaExchange.Api.Enums;
using ManiaExchange.Api.Models;

namespace ManiaExchange.Api;

[ApiClient("https://trackmania.exchange")]
public class TmxTmApi : ApiBase<TmxTmApi>
{
    private readonly string _userAgent;
    
    public TmxTmApi(string userAgent)
    {
        _userAgent = userAgent;
    }

    /// <summary>
    /// Quickly add a Map to a specified Mappack using an existing Map on MX.
    /// </summary>
    /// <param name="mappackId">MX Mappack identifier</param>
    /// <param name="trackId">MX TrackID/MapID OR uid from Gbx file to add to the mappack</param>
    /// <param name="secret">API Secret from Edit Mappack Info</param>
    /// <returns></returns>
    public Task<TmxActionResponse?> AddMapToMappackAsync(long mappackId, string trackId, string secret) =>
        WithUserAgent(_userAgent)
            .WithQueryParam("secret", secret)
            .PostJsonAsync<TmxActionResponse>("/api/mappack/manage/{mappackId}/add_map/{trackId}", mappackId, trackId);

    /// <summary>
    /// Sets a Map inside the Mappack to the desired Status. Useful to e.g. approve a user's submission.
    /// </summary>
    /// <param name="id">MX Mappack identifier</param>
    /// <param name="mIdString">MX TrackID/MapID OR uid from Gbx file to add to the mappack</param>
    /// <param name="status">MX Mappack Map Status to be set</param>
    /// <param name="secret">API Secret from Edit Mappack Info</param>
    /// <returns></returns>
    public Task<TmxActionResponse?> ChangeMapStatusInMappackAsync(long id, string mIdString, TmxStatus status, string secret) =>
        WithUserAgent(_userAgent)
            .WithQueryParam("secret", secret)
            .PostJsonAsync<TmxActionResponse>("/api/mappack/manage/{id}/map_status/{status}/{midstring}", id, (int)status,
                mIdString);

    /// <summary>
    /// Downloads a *.Map.Gbx file using the specified MX Map ID.
    /// </summary>
    /// <param name="id">MX MapID / TrackID</param>
    /// <param name="shortName">Only needed to download unlisted maps. Note: the shortName should be added as follows, if necessary: ...{id}/{shortName}</param>
    /// <returns></returns>
    public Task<Stream> DownloadMapAsync(long id, string? shortName = null) =>
        WithUserAgent(_userAgent)
            .WithQueryParam("shortName", shortName)
            .GetStreamAsync("/maps/download/{id}", id);

    /// <summary>
    /// Download a MX Map's image. Check the Content-Header's content-type for the image file type. Will return empty result if no image is available (...under the specified position).
    /// </summary>
    /// <param name="id">MX MapID / TrackID</param>
    /// <param name="pos">Image position index- Check via Map Info beforehand, how many images are availabl, that's the maximum</param>
    /// <returns></returns>
    public Task<Stream> DownloadMapImageHQAsync(long id, int pos) =>
        WithUserAgent(_userAgent)
            .GetStreamAsync("/maps/{id}/image/{pos}", id, pos);

    /// <summary>
    /// Download a MX Map's image in low quality. Check the Content-Header's content-type for the image file type (typically image/webp). Will return empty result if no image is available (...under the specified position).
    /// </summary>
    /// <param name="id">MX MapID / TrackID</param>
    /// <param name="pos">Image position index- Check via Map Info beforehand, how many images are availabl, that's the maximum</param>
    /// <returns></returns>
    public Task<Stream> DownloadMapImageLQAsync(long id, int pos) =>
        WithUserAgent(_userAgent)
            .GetStreamAsync("/maps/{id}/imagethumb/{pos}", id, pos);

    /// <summary>
    /// Safe option that gets either the first map image (if available) or the map thumbnail from the Gbx file.
    /// </summary>
    /// <param name="id">MX MapID / TrackID</param>
    /// <returns></returns>
    public Task<Stream> DownloadMapImageSafeAsync(long id) =>
        WithUserAgent(_userAgent)
            .GetStreamAsync("/maps/screenshot_normal/{id}", id);

    /// <summary>
    /// Get a Map's original thumbnail as embedded in it's .Map.Gbx file.
    /// </summary>
    /// <param name="id">MX MapID / TrackID</param>
    /// <returns></returns>
    public Task<Stream> DownloadMapThumbnail(long id) =>
        WithUserAgent(_userAgent)
            .GetStreamAsync("/maps/thumbnail/{id}", id);

    /// <summary>
    /// Download a .zip of a Mappack on MX.
    /// </summary>
    /// <param name="id">MX Mappack ID</param>
    /// <param name="secret">API Secret - only needed to download unreleased or undownloadable mappacks</param>
    /// <returns></returns>
    public Task<Stream> DownloadMappack(long id, string? secret = null) =>
        WithUserAgent(_userAgent)
            .WithQueryParam("secret", secret)
            .GetStreamAsync("/mappack/download/{id}", id);

    /// <summary>
    /// Download a MX Mappack's Thumbnail image.
    /// </summary>
    /// <param name="id">MX MappackID</param>
    /// <returns></returns>
    public Task<Stream> DownloadMappackThumbnailAsync(long id) =>
        WithUserAgent(_userAgent)
            .GetStreamAsync("/mappack/thumbnail/{id}", id);

    /// <summary>
    /// Get the authors of a map.
    /// </summary>
    /// <param name="id">MX TrackID/MapID</param>
    /// <returns></returns>
    public Task<TmxMapAuthor[]?> GetMapAuthorsAsync(long id) =>
        WithUserAgent(_userAgent)
            .GetJsonAsync<TmxMapAuthor[]>("/api/maps/get_authors/{id}", id);

    /// <summary>
    /// Get information for one or multiple maps using either TrackIDs from MX or the uid value from the Gbx file. Note: Unlisted and hidden maps are omitted.
    /// </summary>
    /// <param name="ids">MX MapIDs or UIDs (uid from Gbx file, max. 50 entries)</param>
    /// <returns></returns>
    public Task<TmxMapInfo[]?> GetMapInfoAsync(params long[] ids) =>
        WithUserAgent(_userAgent)
            .WithQueryParam("format", TmxOutputFormat.Json)
            .GetJsonAsync<TmxMapInfo[]>("/api/maps/get_map_info/multi/{ids}", string.Join(',', ids));
    
    /// <summary>
    /// Get Map information using the MX Map identifier.
    /// </summary>
    /// <param name="id">MX MapID / TrackID</param>
    /// <param name="shortName">Only needed to download unlisted maps. Note: the shortName should be added as follows, if necessary: ...{id}/{shortName}</param>
    /// <returns></returns>
    public Task<TmxMapInfo?> GetMapInfoAsync(long id, string? shortName = null) => 
        WithUserAgent(_userAgent)
            .WithQueryParam("shortName", shortName)
            .GetJsonAsync<TmxMapInfo>("/api/maps/get_map_info/id/{id}", id);

    /// <summary>
    /// Get info for a single map
    /// </summary>
    /// <param name="uid">Gbx uid value from the Map's Gbx file</param>
    /// <param name="shortName">Only needed to download unlisted maps. Note: the shortName should be added as follows, if necessary: ...{id}/{shortName}</param>
    /// <returns></returns>
    public Task<TmxMapInfo?> GetMapInfoAsync(string uid, string? shortName = null) => 
        WithUserAgent(_userAgent)
            .GetJsonAsync<TmxMapInfo>("/api/maps/get_map_info/uid/{uid}", uid);

    /// <summary>
    /// Get a list of all objects / items embedded in a map and if they are to be found on IX.
    ///
    /// Note: Since items are purely matched to IX using the ObjectPath and the ObjectAuthor, it
    /// is not guaranteed to have a single item matched to those two parameters, hence no ItemID
    /// to IX can be given. The item can be searched for using those two parameters.
    /// </summary>
    /// <param name="id">MX MapID / TrackID</param>
    /// <returns></returns>
    public Task<TmxMapObject[]?> GetMapObjectsAsync(long id) =>
        WithUserAgent(_userAgent)
            .GetJsonAsync<TmxMapObject[]>("/api/maps/embeddedobjects/{id}", id);

    /// <summary>
    /// Get a list of all submitted replays on a map.
    ///
    /// Note: MX Leaderboards are restricted to 25 records per map.
    /// </summary>
    /// <param name="id">MX TrackID / MapID</param>
    /// <param name="amount">Amount of replays starting from the MX World Record to get (limited to 25)</param>
    /// <returns></returns>
    public Task<TmxReplayInfo[]?> GetMapRecordsAsync(long id, int? amount = null) =>
        WithUserAgent(_userAgent)
            .WithQueryParam("amount", amount)
            .GetJsonAsync<TmxReplayInfo[]>("/api/replays/get_replays/{id}", id);

    /// <summary>
    /// Receive info about a mappack using it's MappackID.
    /// </summary>
    /// <param name="id">MX MappackID</param>
    /// <param name="secret">If the mappack is unreleased, the mappack secret (Mappack -> Edit Info) must be supplied</param>
    /// <returns></returns>
    public Task<TmxMappackInfo?> GetMappackInfoAsync(long id, string? secret = null) =>
        WithUserAgent(_userAgent)
            .WithQueryParam("secret", secret)
            .GetJsonAsync<TmxMappackInfo>("/api/mappack/get_info/{id}", id);

    /// <summary>
    /// Get mappack maps using the MappackID.
    ///
    /// Use secret to get a complete list of maps and optionally filter them by their Status (see Mappack Map Status).
    /// </summary>
    /// <param name="id">MX MappackID</param>
    /// <param name="secret">If the mappack is unreleased, the mappack secret (Mappack -> Edit Info) must be supplied</param>
    /// <returns></returns>
    public Task<TmxMappackMapInfo[]?> GetMappackMapsAsync(long id, string? secret = null) =>
        WithUserAgent(_userAgent)
            .WithQueryParam("secret", secret)
            .GetJsonAsync<TmxMappackMapInfo[]>("/api/mappack/get_mappack_tracks/{id}", id);

    /// <summary>
    /// Get replay info based on the ReplayID on MX.
    /// </summary>
    /// <param name="id">MX ReplayID</param>
    /// <returns></returns>
    public Task<TmxReplayInfo?> GetReplayAsync(long id) =>
        WithUserAgent(_userAgent)
            .GetJsonAsync<TmxReplayInfo>("/api/replays/get_replay_info/{id}", id);

    /// <summary>
    /// Get an array of all current map & mappack / item & set tags.
    /// </summary>
    /// <returns></returns>
    public Task<TmxTag[]?> GetTagsAsync() =>
        WithUserAgent(_userAgent)
            .GetJsonAsync<TmxTag[]>("/api/tags/gettags");

    /// <summary>
    /// Gets the info for a single map using the uid. Succeeded by Get Map Info (Multi).
    /// </summary>
    /// <param name="uid">uid string from Gbx file</param>
    /// <returns></returns>
    [Obsolete]
    public Task<TmxMapInfo?> GetTrackInfoByUidAsync(string uid) =>
        WithUserAgent(_userAgent)
            .GetJsonAsync<TmxMapInfo>("/api/tracks/get_track_info/uid/{uid}", uid);

    /// <summary>
    /// Get MX User info using the MX UserID
    /// </summary>
    /// <param name="userId">MX UserID</param>
    /// <returns></returns>
    public Task<TmxUserInfo?> GetUserInfoAsync(long userId) =>
        WithUserAgent(_userAgent)
            .GetJsonAsync<TmxUserInfo>("/api/users/get_user_info/{userid}", userId);

    /// <summary>
    /// Get one or multiple User's seasonal / cumulative leaderboard stats.
    /// </summary>
    /// <param name="seasonId">Identifier of the season (see Get LB Seasons method). -1: Cumulative leaderboard</param>
    /// <param name="ids">MX UserIDs</param>
    /// <returns></returns>
    public Task<TmxUserLeaderboardStats[]?> GetUserLeaderboardStatsAsync(int seasonId, params long[] ids) =>
        WithUserAgent(_userAgent)
            .GetJsonAsync<TmxUserLeaderboardStats[]>("/api/leaderboard/season/{SeasonID}/user/{ids}", seasonId,
                string.Join(',', ids));

    /// <summary>
    /// Removes a Map entry from the specified mappack.
    /// </summary>
    /// <param name="id">MX Mappack identifier</param>
    /// <param name="mIdString">MX TrackID/MapID OR uid from Gbx file to add to the mappack</param>
    /// <param name="secret">API Secret from Edit Mappack Info</param>
    /// <returns></returns>
    public Task<TmxActionResponse?> RemoveMapFromMappackAsync(long id, string mIdString, string secret) =>
        WithUserAgent(_userAgent)
            .DeleteJsonAsync<TmxActionResponse>("/api/mappack/manage/{id}/remove_map/{midstring}", id, mIdString,
                secret);

    /// <summary>
    /// Search through the MX Leaderboard (cumulative / seasonal). The results are paged.
    /// </summary>
    /// <param name="searchOptions">Search parameters</param>
    /// <returns></returns>
    public Task<TmxLeaderboardSearchResult?> SearchLeaderboardAsync(Action<TmxLeaderboardSearchOptions>? searchOptions = null) =>
        WithUserAgent(_userAgent)
            .WithQueryParam("api", "on")
            .WithQueryParam("format", TmxOutputFormat.Json)
            .WithQueryOptions(searchOptions)
            .GetJsonAsync<TmxLeaderboardSearchResult>("/leaderboard/search");

    /// <summary>
    /// Search Videos for Maps using various filters. The results are paged.
    /// Use the trackid filter to get videos for a specific map.
    /// </summary>
    /// <param name="limit">Page size - Min. is 20, max. is 100</param>
    /// <param name="page">Current page of the search results</param>
    /// <param name="random">1: Will return one random result from the query</param>
    /// <param name="priord">Primary order (default: submitted newest)</param>
    /// <param name="secord">Secondary Order (default: none)</param>
    /// <param name="userId">Submitted by MX UserID</param>
    /// <param name="creatorId">Created by MX UserID</param>
    /// <param name="trackId">Videos for this TrackID/MapID</param>
    /// <param name="trackUserId">MX UserID of creator of featured map in video (videos received)</param>
    /// <param name="name">Name of Video</param>
    /// <param name="author">MX Username of submitter or Channel name of Video</param>
    /// <param name="hoster">Video hoster</param>
    /// <returns></returns>
    public Task<TmxVideoSearchResult?> SearchMapVideosAsync(
        int? limit = null,
        int? page = null,
        int? random = null,
        TmxVideoSearchOrder? priord = null,
        TmxVideoSearchOrder? secord = null,
        long? userId = null,
        long? creatorId = null,
        long? trackId = null,
        long? trackUserId = null,
        string? name = null,
        string? author = null,
        TmxVideoHoster? hoster = null
    ) =>
        WithUserAgent(_userAgent)
            .WithQueryParam("api", "on")
            .WithQueryParam("format", TmxOutputFormat.Json)
            .WithQueryParam("limit", limit)
            .WithQueryParam("page", page)
            .WithQueryParam("random", random)
            .WithQueryParam("priord", (int?) priord)
            .WithQueryParam("secord", (int?) secord)
            .WithQueryParam("userid", userId)
            .WithQueryParam("creatorid", creatorId)
            .WithQueryParam("trackid", trackId)
            .WithQueryParam("trackuid", trackUserId)
            .WithQueryParam("name", name)
            .WithQueryParam("author", author)
            .WithQueryParam("hoster", (int?) hoster)
            .GetJsonAsync<TmxVideoSearchResult>("/videosearch/search");
}
