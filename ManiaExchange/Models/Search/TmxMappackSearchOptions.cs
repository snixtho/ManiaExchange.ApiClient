using Hawf.Attributes;
using ManiaExchange.Api.Enums;

namespace ManiaExchange.Api.Models.Search;

public class TmxMappackSearchOptions : TmxSearchOptions
{
    /// <summary>
    /// 1: Will return one random result from the query
    /// </summary>
    [QueryProperty("random")]
    public int? Random { get; set; }
    /// <summary>
    /// Mappack Search Mode
    /// </summary>
    [QueryProperty("priord", true)]
    public TmxMappackSearchOrder? Priord { get; set; }
    /// <summary>
    /// Primary Order (default: Created newest)
    /// </summary>
    [QueryProperty("secord", true)]
    public TmxMappackSearchOrder? Secord { get; set; }
    /// <summary>
    /// Mappack name
    /// </summary>
    [QueryProperty("name")]
    public IEnumerable<string>? Name { get; set; }
    /// <summary>
    /// (Partial) MX username of the creator
    /// </summary>
    [QueryProperty("creator")]
    public IEnumerable<string>? Creator { get; set; }
    /// <summary>
    /// MX UserID of mappack creator
    /// </summary>
    [QueryProperty("creatorid")]
    public long? CreatorId { get; set; }
    /// <summary>
    /// MX Mappack Type
    /// </summary>
    [QueryProperty("type", true)]
    public TmxMappackType? Type { get; set; }
    /// <summary>
    /// Titlepack used for all tracks (only if all maps share the same)
    /// </summary>
    [QueryProperty("tpack")]
    public IEnumerable<string>? TitlePack { get; set; }
    /// <summary>
    /// Environment used for all tracks (only if all maps share the same)
    /// </summary>
    [QueryProperty("environments")]
    public IEnumerable<int>? Environments { get; set; }
    /// <summary>
    /// Primary Mappack tag (see Get Tags method)
    /// </summary>
    [QueryProperty("style")]
    public int? Style { get; set; }
    /// <summary>
    /// Mappack tags (see Get Tags method)
    /// </summary>
    [QueryProperty("tags")]
    public IEnumerable<int>? Tags { get; set; }
    /// <summary>
    /// Mappack tags to exclude (see Get Tags method)
    /// </summary>
    [QueryProperty("etags")]
    public IEnumerable<int>? ExcludeTags { get; set; }
    /// <summary>
    /// 1: Mappack must contain all of the selected tags
    /// </summary>
    [QueryProperty("tagsinc")]
    public int? TagsInc { get; set; }
    /// <summary>
    /// Minimum map count
    /// </summary>
    [QueryProperty("trackcount")]
    public int? TrackCount { get; set; }
    /// <summary>
    /// 1: Only mappack requests (same as mode=2)
    /// </summary>
    [QueryProperty("request")]
    public int? Request { get; set; }
    /// <summary>
    /// 1: Only mappacks with thumbnail
    /// </summary>
    [QueryProperty("thumbnail")]
    public int? Thumbnail { get; set; }
}