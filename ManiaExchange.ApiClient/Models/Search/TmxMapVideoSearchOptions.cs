using Hawf.Attributes;
using ManiaExchange.ApiClient.Enums;

namespace ManiaExchange.ApiClient.Models.Search;

public class TmxMapVideoSearchOptions : TmxSearchOptions
{
    [QueryProperty("random")]
    public int? Random { get; set; }
    [QueryProperty("priord", true)]
    public TmxVideoSearchOrder? Priord { get; set; }
    [QueryProperty("secord", true)]
    public TmxVideoSearchOrder? Secord { get; set; }
    [QueryProperty("userid")]
    public long? UserId { get; set; }
    [QueryProperty("creatorid")]
    public long? CreatorId { get; set; }
    [QueryProperty("trackuid")]
    public long? TrackId { get; set; }
    [QueryProperty("name")]
    public string? Name { get; set; }
    [QueryProperty("author")]
    public string? Author { get; set; }
    [QueryProperty("hoster", true)]
    public TmxVideoHoster? Hoster { get; set; }
}