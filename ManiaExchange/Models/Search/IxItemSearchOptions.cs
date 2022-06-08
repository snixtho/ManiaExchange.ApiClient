using Hawf.Attributes;
using ManiaExchange.Api.Enums;

namespace ManiaExchange.Api.Models.Search;

public class IxItemSearchOptions
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
    /// Partial or full name of an item
    /// </summary>
    [QueryProperty("itemname")]
    public IEnumerable<string>? ItemName { get; set; }
    /// <summary>
    /// Partial or full filename of an item
    /// </summary>
    [QueryProperty("filename")]
    public IEnumerable<string>? FileName { get; set; }
    /// <summary>
    /// MX UserID of uploader
    /// </summary>
    [QueryProperty("userid")]
    public long? UserId { get; set; }
    /// <summary>
    /// Partial or full name of the item uploader (MX username)
    /// </summary>
    [QueryProperty("uploader")]
    public IEnumerable<string>? Uploader { get; set; }
    /// <summary>
    /// Partial or full ingame login of item creator
    /// </summary>
    [QueryProperty("authorlogin")]
    public IEnumerable<string>? AuthorLogin { get; set; }
    /// <summary>
    /// (Partial) MX Username OR ingame login of item creator
    /// </summary>
    [QueryProperty("anyauthor")]
    public IEnumerable<bool>? AnyAuthor { get; set; }
    /// <summary>
    /// Item Type
    /// </summary>
    [QueryProperty("itype", true)]
    public IxItemType? ItemType { get; set; }
    /// <summary>
    /// Collection (/environment) filter
    /// </summary>
    [QueryProperty("collections", true)]
    public IEnumerable<TmxEnvironment>? Collections { get; set; }
    /// <summary>
    /// Included in Set with IX SetID
    /// </summary>
    [QueryProperty("setid")]
    public long? SetId { get; set; }
    /// <summary>
    /// Minimum length of author comments on the item
    /// </summary>
    [QueryProperty("commentsminlength")]
    public int? CommentsMinLength { get; set; }
    /// <summary>
    /// 1: Item must have a custom thumbnail/image
    /// </summary>
    [QueryProperty("customthumb")]
    public int? CustomThumbnail { get; set; }
    /// <summary>
    /// For Blocks: Name of original block that the custom block was created out of
    /// </summary>
    [QueryProperty("originalblock")]
    public IEnumerable<string>? OriginalBlock { get; set; }
    /// <summary>
    /// For Blocks: Navigation String in map editor (like 1-1-1 or 3-4-2-1) of origin block
    /// </summary>
    [QueryProperty("nav")]
    public string? Nav { get; set; }
    /// <summary>
    /// 1: Item is not included in a .zip set
    /// </summary>
    [QueryProperty("setinclusion")]
    public int? SetInclusion { get; set; }
    /// <summary>
    /// Game, which the item is for
    /// </summary>
    [QueryProperty("game", true)]
    public IxGame? Game { get; set; }
    /// <summary>
    /// Tag IDs, see Get Tags method
    /// </summary>
    [QueryProperty("tags")]
    public IEnumerable<int>? Tags { get; set; }
    /// <summary>
    /// Tag IDs to exclude, see Get Tags method
    /// </summary>
    [QueryProperty("etags")]
    public IEnumerable<int>? ExcludeTags { get; set; }
    /// <summary>
    /// 0: items include one or more of specified tags (default), 1: items must include all specified tags
    /// </summary>
    [QueryProperty("tagsinc")]
    public int? TagsInclude { get; set; }
    /// <summary>
    /// 0: Show only released items (default), 1: Show only unreleased items
    /// </summary>
    [QueryProperty("unreleased")]
    public int? Unreleased { get; set; }
}
