using Hawf.Attributes;
using ManiaExchange.Api.Enums;

namespace ManiaExchange.Api.Models.Search;

public class TmxMapSearchOptions : TmxSearchOptions
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
    public TmxMapSearchOrder? Priord { get; set; }
    /// <summary>
    /// Secondary order (default: none)
    /// </summary>
    [QueryProperty("secord", true)]
    public TmxMapSearchOrder? Secord { get; set; }
    /// <summary>
    /// Special search mode
    /// </summary>
    [QueryProperty("mode", true)]
    public TmxMapSearchMode? Mode { get; set; }
    /// <summary>
    /// Partial or a full name of a map
    /// </summary>
    [QueryProperty("trackname")]
    public IEnumerable<string>? TrackName { get; set; }
    /// <summary>
    /// MX username of the map uploader
    /// </summary>
    [QueryProperty("author")]
    public IEnumerable<string>? Author { get; set; }
    /// <summary>
    /// Ingame login of map uploader
    /// </summary>
    [QueryProperty("mpauthor")]
    public IEnumerable<string>? MpAuthor { get; set; }
    /// <summary>
    /// MX username OR ingame login of map uploader
    /// </summary>
    [QueryProperty("anyauthor")]
    public IEnumerable<string>? AnyAuthor { get; set; }
    /// <summary>
    /// Name of texture mod used
    /// </summary>
    [QueryProperty("mod")]
    public string? Mod { get; set; }
    /// <summary>
    /// UserID, depending on mode used
    /// </summary>
    [QueryProperty("authorid")]
    public string? AuthorId { get; set; }
    /// <summary>
    /// Ingame map type used
    /// </summary>
    [QueryProperty("mtype")]
    public IEnumerable<string>? MapType { get; set; }
    /// <summary>
    /// Titlepack used
    /// </summary>
    [QueryProperty("tpack")]
    public IEnumerable<string>? TitlePack { get; set; }
    /// <summary>
    /// MX Replay Type
    /// </summary>
    [QueryProperty("rtype")]
    public TmxReplayType? ReplayType { get; set; }
    /// <summary>
    /// Main map style (first selected map tag)
    /// </summary>
    [QueryProperty("style")]
    public int? Style { get; set; }
    /// <summary>
    /// Tag IDs, see Get Tags method
    /// </summary>
    [QueryProperty("tags")]
    public IEnumerable<int>? Tags { get; set; }
    /// <summary>
    /// 0: maps include one or more of specified tags (default), 1: maps must include all specified tags
    /// </summary>
    [QueryProperty("tagsinc")]
    public int? TagsInc { get; set; }
    /// <summary>
    /// Tag IDs to exclude, see Get Tags method
    /// </summary>
    [QueryProperty("etags")]
    public IEnumerable<int>? ExcludeTags { get; set; }
    /// <summary>
    /// MX map length
    /// </summary>
    [QueryProperty("length")]
    public int? Length { get; set; }
    /// <summary>
    /// Operator for the length filter
    /// </summary>
    [QueryProperty("lengthop")]
    public TmxSearchOperator? LengthOp { get; set; }
    /// <summary>
    /// Environments filter
    /// </summary>
    [QueryProperty("environments")]
    public IEnumerable<TmxEnvironment>? Environments { get; set; }
    /// <summary>
    /// Vehicles filter
    /// </summary>
    [QueryProperty("vehicles")]
    public IEnumerable<TmxVehicles>? Vehicles { get; set; }
    /// <summary>
    /// MappackID filter
    /// </summary>
    [QueryProperty("mid")]
    public long? MappackId { get; set; }
    /// <summary>
    /// If Mappack is defined: Status in the mappack
    /// </summary>
    [QueryProperty("mpstatus")]
    public int? MappacKStatus { get; set; }
    /// <summary>
    /// VideoID of video that contains maps (requires appropiate mode)
    /// </summary>
    [QueryProperty("videoid")]
    public long? VideoId { get; set; }
    /// <summary>
    /// MX map difficulty
    /// </summary>
    [QueryProperty("difficulty")]
    public TmxMapDifficulty? Difficulty { get; set; }
    /// <summary>
    /// Map requires TMUnlimiter (TM2.MX, SMX only)
    /// </summary>
    [QueryProperty("unlimiter")]
    public bool? Unlimiter { get; set; }
    /// <summary>
    /// 0: Show only released maps (default), 1: Show only unreleased maps
    /// </summary>
    [QueryProperty("unreleased")]
    public int? Unreleased { get; set; }
    /// <summary>
    /// Minimum length of author comments
    /// </summary>
    [QueryProperty("commentsminlength")]
    public int? CommentsMinLength { get; set; }
    /// <summary>
    /// 1: Map must have a custom image uploaded
    /// </summary>
    [QueryProperty("customscreenshot")]
    public int? CustomScreenshot { get; set; }
    /// <summary>
    /// 0: No Envimix, 1: Only Envimix (= Vehicle doesn't match Environment)
    /// </summary>
    [QueryProperty("envmix")]
    public int? EnvMix { get; set; }
    /// <summary>
    /// 0: No embedded objects, 1: Must have embedded objects
    /// </summary>
    [QueryProperty("embeddedobjects")]
    public int? EmbeddedObjects { get; set; }
    /// <summary>
    /// Filter by map release month (1 for August until 12 for December)
    /// </summary>
    [QueryProperty("month")]
    public int? Month { get; set; }
    /// <summary>
    /// Filter by map release year
    /// </summary>
    [QueryProperty("year")]
    public int? Year { get; set; }
}
