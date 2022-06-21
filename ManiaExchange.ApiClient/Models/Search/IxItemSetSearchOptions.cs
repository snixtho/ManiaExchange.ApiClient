using Hawf.Attributes;
using ManiaExchange.ApiClient.Enums;

namespace ManiaExchange.ApiClient.Models.Search;

public class IxItemSetSearchOptions : TmxSearchOptions
{
    /// <summary>
    /// 1: Will return one random result from the query
    /// </summary>
    [QueryProperty("random")]
    public int? Random { get; set; }
    /// <summary>
    /// Primary order (default: uploaded newest)
    /// </summary>
    [QueryProperty("priord", true)]
    public IxItemSearchOrder? Priord { get; set; }
    /// <summary>
    /// Secondary order (default: none)
    /// </summary>
    [QueryProperty("secord", true)]
    public IxItemSearchOrder? Secord { get; set; }
    /// <summary>
    /// Special search mode
    /// </summary>
    [QueryProperty("mode", true)]
    public IxSetSearchMode? Mode { get; set; }
    /// <summary>
    /// Partial or full name of a Set
    /// </summary>
    [QueryProperty("setname")]
    public IEnumerable<string>? SetName { get; set; }
    /// <summary>
    /// Partial or full filename of a Set
    /// </summary>
    [QueryProperty("filename")]
    public IEnumerable<string>? FileName { get; set; }
    /// <summary>
    /// MX UserID of uploader
    /// </summary>
    [QueryProperty("userid")]
    public long? UserId { get; set; }
    /// <summary>
    /// Partial or full MX username of Set uploader
    /// </summary>
    [QueryProperty("author")]
    public IEnumerable<string>? Author { get; set; }
    /// <summary>
    /// Collection (/environment) filter
    /// </summary>
    [QueryProperty("collections", true)]
    public IEnumerable<TmxEnvironment>? Collections { get; set; }
    /// <summary>
    /// Minimum length of author comments on the Set
    /// </summary>
    [QueryProperty("commentsminlength")]
    public int? CommentsMinLength { get; set; }
    /// <summary>
    /// Game, for which the Set is for
    /// </summary>
    [QueryProperty("game", true)]
    public IxGame? Game { get; set; }
    /// <summary>
    /// Tag IDs, see Get Tags method
    /// </summary>
    [QueryProperty("tags")]
    public IEnumerable<int>? Tags { get; set; }
    /// <summary>
    /// 0: Show only released items (default), 1: Show only unreleased items
    /// </summary>
    [QueryProperty("unreleased")]
    public int? Unreleased { get; set; }
}