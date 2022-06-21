using Hawf.Attributes;
using Hawf.Client;
using ManiaExchange.ApiClient.Api.Models;
using ManiaExchange.ApiClient.Enums;
using ManiaExchange.ApiClient.Models;
using ManiaExchange.ApiClient.Models.Search;

namespace ManiaExchange.ApiClient;

[ApiClient("https://trackmania.exchange")]
public class MxMapsBase<T> : MxBase<T> where T : MxMapsBase<T>
{
    protected MxMapsBase(string userAgent) : base(userAgent)
    {
    }
    
    /// <summary>
    /// Quickly add a Map to a specified Mappack using an existing Map on MX.
    /// </summary>
    /// <param name="mappackId">MX Mappack identifier</param>
    /// <param name="trackId">MX TrackID/MapID OR uid from Gbx file to add to the mappack</param>
    /// <param name="secret">API Secret from Edit Mappack Info</param>
    /// <returns></returns>
    public Task<TmxActionResponse?> AddMapToMappackAsync(long mappackId, string trackId, string secret) =>
        WithQueryParam("secret", secret)
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
        WithQueryParam("secret", secret)
            .PostJsonAsync<TmxActionResponse>("/api/mappack/manage/{id}/map_status/{status}/{midstring}", id, (int)status,
                mIdString);

    /// <summary>
    /// Downloads a *.Map.Gbx file using the specified MX Map ID.
    /// </summary>
    /// <param name="id">MX MapID / TrackID</param>
    /// <param name="shortName">Only needed to download unlisted maps. Note: the shortName should be added as follows, if necessary: ...{id}/{shortName}</param>
    /// <returns></returns>
    public Task<Stream> DownloadMapAsync(long id, string? shortName = null) =>
        CacheResponseFor(CacheTime)
            .WithQueryParam("shortName", shortName)
            .GetStreamAsync("/maps/download/{id}", id);

    /// <summary>
    /// Download a MX Map's image. Check the Content-Header's content-type for the image file type. Will return empty result if no image is available (...under the specified position).
    /// </summary>
    /// <param name="id">MX MapID / TrackID</param>
    /// <param name="pos">Image position index- Check via Map Info beforehand, how many images are availabl, that's the maximum</param>
    /// <returns></returns>
    public Task<Stream> DownloadMapImageHQAsync(long id, int pos) =>
        CacheResponseFor(CacheTime)
            .GetStreamAsync("/maps/{id}/image/{pos}", id, pos);

    /// <summary>
    /// Download a MX Map's image in low quality. Check the Content-Header's content-type for the image file type (typically image/webp). Will return empty result if no image is available (...under the specified position).
    /// </summary>
    /// <param name="id">MX MapID / TrackID</param>
    /// <param name="pos">Image position index- Check via Map Info beforehand, how many images are availabl, that's the maximum</param>
    /// <returns></returns>
    public Task<Stream> DownloadMapImageLQAsync(long id, int pos) =>
        CacheResponseFor(CacheTime)
            .GetStreamAsync("/maps/{id}/imagethumb/{pos}", id, pos);

    /// <summary>
    /// Safe option that gets either the first map image (if available) or the map thumbnail from the Gbx file.
    /// </summary>
    /// <param name="id">MX MapID / TrackID</param>
    /// <returns></returns>
    public Task<Stream> DownloadMapImageSafeAsync(long id) =>
        CacheResponseFor(CacheTime)
            .GetStreamAsync("/maps/screenshot_normal/{id}", id);

    /// <summary>
    /// Get a Map's original thumbnail as embedded in it's .Map.Gbx file.
    /// </summary>
    /// <param name="id">MX MapID / TrackID</param>
    /// <returns></returns>
    public Task<Stream> DownloadMapThumbnail(long id) =>
        CacheResponseFor(CacheTime)
            .GetStreamAsync("/maps/thumbnail/{id}", id);

    /// <summary>
    /// Download a .zip of a Mappack on MX.
    /// </summary>
    /// <param name="id">MX Mappack ID</param>
    /// <param name="secret">API Secret - only needed to download unreleased or undownloadable mappacks</param>
    /// <returns></returns>
    public Task<Stream> DownloadMappack(long id, string? secret = null) =>
        CacheResponseFor(CacheTime)
            .WithQueryParam("secret", secret)
            .GetStreamAsync("/mappack/download/{id}", id);

    /// <summary>
    /// Download a MX Mappack's Thumbnail image.
    /// </summary>
    /// <param name="id">MX MappackID</param>
    /// <returns></returns>
    public Task<Stream> DownloadMappackThumbnailAsync(long id) =>
        CacheResponseFor(CacheTime)
            .GetStreamAsync("/mappack/thumbnail/{id}", id);

    /// <summary>
    /// Get the authors of a map.
    /// </summary>
    /// <param name="id">MX TrackID/MapID</param>
    /// <returns></returns>
    public Task<TmxMapAuthor[]?> GetMapAuthorsAsync(long id) =>
        CacheResponseFor(CacheTime)
            .GetJsonAsync<TmxMapAuthor[]>("/api/maps/get_authors/{id}", id);

    /// <summary>
    /// Get information for one or multiple maps using either TrackIDs from MX or the uid value from the Gbx file. Note: Unlisted and hidden maps are omitted.
    /// </summary>
    /// <param name="ids">MX MapIDs or UIDs (uid from Gbx file, max. 50 entries)</param>
    /// <returns></returns>
    public Task<TmxMapInfo[]?> GetMapInfoAsync(params long[] ids) =>
        CacheResponseFor(CacheTime)
            .WithQueryParam("format", TmxOutputFormat.Json)
            .GetJsonAsync<TmxMapInfo[]>("/api/maps/get_map_info/multi/{ids}", string.Join(',', ids));
    
    /// <summary>
    /// Get Map information using the MX Map identifier.
    /// </summary>
    /// <param name="id">MX MapID / TrackID</param>
    /// <param name="shortName">Only needed to download unlisted maps. Note: the shortName should be added as follows, if necessary: ...{id}/{shortName}</param>
    /// <returns></returns>
    public Task<TmxMapInfo?> GetMapInfoAsync(long id, string? shortName = null) => 
        CacheResponseFor(CacheTime)
            .WithQueryParam("shortName", shortName)
            .GetJsonAsync<TmxMapInfo>("/api/maps/get_map_info/id/{id}", id);

    /// <summary>
    /// Get info for a single map
    /// </summary>
    /// <param name="uid">Gbx uid value from the Map's Gbx file</param>
    /// <param name="shortName">Only needed to download unlisted maps. Note: the shortName should be added as follows, if necessary: ...{id}/{shortName}</param>
    /// <returns></returns>
    public Task<TmxMapInfo?> GetMapInfoAsync(string uid, string? shortName = null) =>
        CacheResponseFor(CacheTime)
            .WithQueryParam("shortName", shortName)
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
        CacheResponseFor(CacheTime)
            .GetJsonAsync<TmxMapObject[]>("/api/maps/embeddedobjects/{id}", id);

    /// <summary>
    /// Receive info about a mappack using it's MappackID.
    /// </summary>
    /// <param name="id">MX MappackID</param>
    /// <param name="secret">If the mappack is unreleased, the mappack secret (Mappack -> Edit Info) must be supplied</param>
    /// <returns></returns>
    public Task<TmxMappackInfo?> GetMappackInfoAsync(long id, string? secret = null) =>
        CacheResponseFor(CacheTime)
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
        CacheResponseFor(CacheTime)
            .WithQueryParam("secret", secret)
            .GetJsonAsync<TmxMappackMapInfo[]>("/api/mappack/get_mappack_tracks/{id}", id);

    /// <summary>
    /// Gets the info for a single map using the uid. Succeeded by Get Map Info (Multi).
    /// </summary>
    /// <param name="uid">uid string from Gbx file</param>
    /// <returns></returns>
    [Obsolete]
    public Task<TmxMapInfo?> GetTrackInfoByUidAsync(string uid) =>
        CacheResponseFor(CacheTime)
            .GetJsonAsync<TmxMapInfo>("/api/tracks/get_track_info/uid/{uid}", uid);

    /// <summary>
    /// Get MX User info using the MX UserID
    /// </summary>
    /// <param name="userId">MX UserID</param>
    /// <returns></returns>
    public Task<TmxUserInfo?> GetUserInfoAsync(long userId) =>
        CacheResponseFor(CacheTime)
            .GetJsonAsync<TmxUserInfo>("/api/users/get_user_info/{userid}", userId);



    /// <summary>
    /// Removes a Map entry from the specified mappack.
    /// </summary>
    /// <param name="id">MX Mappack identifier</param>
    /// <param name="mIdString">MX TrackID/MapID OR uid from Gbx file to add to the mappack</param>
    /// <param name="secret">API Secret from Edit Mappack Info</param>
    /// <returns></returns>
    public Task<TmxActionResponse?> RemoveMapFromMappackAsync(long id, string mIdString, string secret) =>
        DeleteJsonAsync<TmxActionResponse>("/api/mappack/manage/{id}/remove_map/{midstring}", id, mIdString,
            secret);

    /// <summary>
    /// Search Videos for Maps using various filters. The results are paged.
    ///
    /// Use the trackid filter to get videos for a specific map.
    /// </summary>
    /// <param name="searchOptions">Search parameters</param>
    /// <returns></returns>
    public Task<TmxVideoSearchResult?> SearchMapVideosAsync(Action<TmxMapVideoSearchOptions>? searchOptions = null) =>
        CacheResponseFor(CacheTime)
            .WithQueryParam("api", "on")
            .WithQueryParam("format", TmxOutputFormat.Json)
            .WithQueryOptions(searchOptions)
            .GetJsonAsync<TmxVideoSearchResult>("/videosearch/search");

    /// <summary>
    /// Search mappacks using various filters. The results are paged.
    /// </summary>
    /// <param name="searchOptions">Search parameters</param>
    /// <returns></returns>
    public Task<TmxMappackSearchResult?> SearchMappacksAsync(Action<TmxMappackSearchOptions>? searchOptions = null) =>
        CacheResponseFor(CacheTime)
            .WithQueryParam("api", "on")
            .WithQueryParam("format", TmxOutputFormat.Json)
            .WithQueryOptions(searchOptions)
            .GetJsonAsync<TmxMappackSearchResult>("/mappacksearch/search");

    /// <summary>
    /// Search maps using various filters. The results are paged.
    /// </summary>
    /// <param name="searchOptions">Search parameters</param>
    /// <returns></returns>
    public Task<TmxMapSearchResult?> SearchMapsAsync(Action<TmxMapSearchOptions>? searchOptions = null) =>
        CacheResponseFor(CacheTime)
            .WithQueryParam("api", "on")
            .WithQueryParam("format", TmxOutputFormat.Json)
            .WithQueryOptions(searchOptions)
            .GetJsonAsync<TmxMapSearchResult>("/mapsearch2/search");

    /// <summary>
    /// Search users on the respective site. TOP10 results are shown, sorted by how well matched the result is to the query.
    ///
    /// This method is useful for quick and low-demand applications.
    /// </summary>
    /// <param name="query">Either: MX username, ingame login or UserID</param>
    /// <returns></returns>
    public Task<TmxSimpleUserInfo[]?> SearchUsersSimpleAsync(string query) =>
        CacheResponseFor(CacheTime)
            .WithQueryParam("query", query)
            .GetJsonAsync<TmxSimpleUserInfo[]>("/api/user/search");
}
