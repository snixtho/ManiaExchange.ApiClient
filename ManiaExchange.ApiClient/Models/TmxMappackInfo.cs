namespace ManiaExchange.ApiClient.Api.Models;

public class TmxMappackInfo
{
    public long ID { get; set; }
    public long UserID { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string TypeName { get; set; }
    public string StyleName { get; set; }
    public string? Titlepack { get; set; }
    public string? EnvironmentName { get; set; }
    public bool Unreleased { get; set; }
    public bool TrackUnreleased { get; set; }
    public bool TrackHidden { get; set; }
    public bool TrackDownloadable { get; set; }
    public bool Downloadable { get; set; }
    public int Downloads { get; set; }
    public bool Request { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Edited { get; set; }
    public string? VideoUrl { get; set; }
    public int TrackCount { get; set; }
    public float MappackValue { get; set; }
    public bool ShowLB { get; set; }
    public DateTime? EndDateLB { get; set; }
    public string TagsString { get; set; }
}