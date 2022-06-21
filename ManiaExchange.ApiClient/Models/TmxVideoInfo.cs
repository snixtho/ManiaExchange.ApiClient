namespace ManiaExchange.ApiClient.Models;

public class TmxVideoInfo
{
    public string Name { get; set; }
    public int AwardCount { get; set; }
    public long TrackUserID { get; set; }
    public string TrackUsername { get; set; }
    public long VideoId { get; set; }
    public string VideoTitle { get; set; }
    public string VideoAuthor { get; set; }
    public string VideoThumbnail { get; set; }
    public string LinkID { get; set; }
    public TmxVideoInfo Provider { get; set; }
    public string ProviderName { get; set; }
    public string VideoLink { get; set; }
    public long UserID { get; set; }
    public string Username { get; set; }
    public DateTime Posted { get; set; }
    public DateTime Submitted { get; set; }
    public long? CreatorUserID { get; set; }
    public string? CreatorUsername { get; set; }
    public int MapCount { get; set; }
    public int TimeStamp { get; set; }
}