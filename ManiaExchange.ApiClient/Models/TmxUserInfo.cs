namespace ManiaExchange.ApiClient.Models;

public class TmxUserInfo
{
    public long UserID { get; set; }
    public string Username { get; set; }
    public string? PlayerLogin { get; set; }
    public string? UplayLogin { get; set; }
    public string Comments { get; set; }
    public bool IsDuo { get; set; }
    public DateTime Registered { get; set; }
    public int TrackCount { get; set; }
    public int MappackCount { get; set; }
    public int ReplayCount { get; set; }
    public int AwardsReceived { get; set; }
    public int AwardsGiven { get; set; }
    public int CommentsReceived { get; set; }
    public int CommentsGiven { get; set; }
    public int FavouritesCount { get; set; }
    public int VideosReceivedCount { get; set; }
    public int VideosSubmittedCount { get; set; }
    public int VideosCreatedCount { get; set; }
    public long? FeaturedTrackID { get; set; }
    public int WorldRecords { get; set; }
    public int Top10s { get; set; }
}