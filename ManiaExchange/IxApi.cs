using Hawf.Attributes;
using ManiaExchange.Api.Enums;
using ManiaExchange.Api.Models;
using ManiaExchange.Api.Models.Search;

namespace ManiaExchange.Api;

/// <summary>
/// API client for Item Exchange.
/// </summary>
[ApiClient("https://item.exchange")]
public class IxApi : MxBase<IxApi>
{
    public IxApi(string userAgent) : base(userAgent)
    {
    }

    /// <summary>
    /// Downloads a user's basket of items in a .zip.
    /// </summary>
    /// <param name="userId">MX UserID</param>
    /// <param name="ignoreDir">false(default): Puts items in their respective directories, true: Ignores directories of items and puts all in the root directory</param>
    /// <returns></returns>
    public Task<Stream> DownloadBasketAsync(long userId, bool ignoreDir = false) =>
        WithQueryParam("ignDir", ignoreDir)
            .GetStreamAsync("/basket/download/{userID}", userId);

    /// <summary>
    /// Download a single item from IX. Might return either a .Gbx or a .zip file, depending on the given filename OR if the item is in a set and if multiple files are required to load the item (FileName.EndsWith(".zip") || (SetID != 0 && ZipIndex[].Length > 1)).
    /// </summary>
    /// <param name="id">IX Item ID</param>
    /// <returns></returns>
    public Task<Stream> DownloadItemAsync(long id) =>
        GetStreamAsync("/item/download/{id}", id);

    /// <summary>
    /// Download a single item set from IX (.zip).
    /// </summary>
    /// <param name="id">IX Item Set Identifier</param>
    /// <returns></returns>
    public Task<Stream> DownloadItemSetAsync(long id) => 
        GetStreamAsync("/set/download/{id}", id);

    /// <summary>
    /// Gets an IX User's basket, sorted by Set (grouped) and then the date in which the item was added.
    /// </summary>
    /// <param name="userId">MX UserID to get the basket from</param>
    /// <returns></returns>
    public Task<IxBasket?> GetBasketAsync(long userId) =>
        GetJsonAsync<IxBasket>("/api/user/get_basket/{userID}", userId);

    /// <summary>
    /// Get an item's icon as displayed ingame.
    /// 
    /// Note: Not all items have an icon. Those will return a placeholder image from IX.
    /// </summary>
    /// <param name="id">IX Item identifier</param>
    /// <returns></returns>
    public Task<Stream> GetItemIconAsync(long id) =>
        GetStreamAsync("/item/icon/{id}");

    /// <summary>
    /// Item information based on IX IDs.
    /// </summary>
    /// <param name="ids">IX Item IDs</param>
    /// <returns></returns>
    public Task<IxItemInfo[]?> GetItemInfoAsync(params long[] ids) =>
        GetJsonAsync<IxItemInfo[]>("/api/item/get_item_info/multi/{ids}", ids);

    /// <summary>
    /// Get an item set image using the position parameter (max: 5). You can get the max. amount of available images using the ImageCount parameter from the Get Set Info Method.
    /// </summary>
    /// <param name="id">IX Set Identifier</param>
    /// <param name="position">Image index, between 1 and 5 (for max. available images, see ImageCount in Get Set Info) - empty or 0 returns first image</param>
    /// <returns></returns>
    public Task<Stream> GetItemSetImageAsync(long id, int position = 0) =>
        GetStreamAsync("/set/image/{id}/{position}", id, position);

    /// <summary>
    /// Item Set information with all included items
    /// </summary>
    /// <param name="ids">ItemExchange Set IDs</param>
    /// <returns></returns>
    public Task<IxItemSetInfo[]?> GetItemSetInfoAsync(params long[] ids) =>
        GetJsonAsync<IxItemSetInfo[]>("/api/set/get_set_info/multi/{ids}", ids);

    /// <summary>
    /// Gets a custom item image that has been uploaded next to the item.
    ///
    /// Note: Not all items have it. You can check it via the HasThumbnail option in Get Item Info.
    /// </summary>
    /// <param name="id">IX Item Identifier</param>
    /// <returns></returns>
    public Task<Stream> GetItemThumbnailAsync(long id) =>
        GetStreamAsync("/item/thumbnail/{id}", id);

    /// <summary>
    /// Search item sets using various filters. The results are paged.
    /// </summary>
    /// <param name="searchOptions">Search parameters</param>
    /// <returns></returns>
    public Task<IxItemSetSearchResult?> SearchItemSetsAsync(Action<IxItemSetSearchOptions>? searchOptions = null) =>
        WithQueryParam("api", "on")
            .WithQueryParam("format", TmxOutputFormat.Json)
            .WithQueryOptions(searchOptions)
            .GetJsonAsync<IxItemSetSearchResult>("/setsearch/search");

    /// <summary>
    /// Search items using various filters. The results are paged.
    /// </summary>
    /// <param name="searchOptions">Search parameters</param>
    /// <returns></returns>
    public Task<IxItemSearchResult?> SearchItemsAsync(Action<IxItemSearchOptions>? searchOptions = null) =>
        WithQueryParam("api", "on")
            .WithQueryParam("format", TmxOutputFormat.Json)
            .WithQueryOptions(searchOptions)
            .GetJsonAsync<IxItemSearchResult>("/itemsearch/search");
}
