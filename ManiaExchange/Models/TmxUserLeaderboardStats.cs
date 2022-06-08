namespace ManiaExchange.Api.Models;

public class TmxUserLeaderboardStats
{
    public long UserID { get; set; }
    public string Username { get; set; }
    public int Position { get; set; }
    public int PositionChange { get; set; }
    public int PreviousPosition { get; set; }
    public double Score { get; set; }
    public double ScoreChange { get; set; }
    public int WorldRecords { get; set; }
    public int WRChange { get; set; }
    public int ReplayCount { get; set; }
    public int ReplayCountChange { get; set; }
    public int Top2s { get; set; }
    public int Top3s { get; set; }
    public float AveragePosition { get; set; }
    public int SeasonID { get; set; }
}