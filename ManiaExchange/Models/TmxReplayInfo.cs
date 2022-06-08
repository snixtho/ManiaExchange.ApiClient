namespace ManiaExchange.Api.Models;

public class TmxReplayInfo
{
    public long ReplayID { get; set; }
    public long UserID { get; set; }
    public string Username { get; set; }
    public long TracKID { get; set; }
    public DateTime UploadedAt { get; set; }
    public long ReplayTime { get; set; }
    public int StuntScore { get; set; }
    public int Respawns { get; set; }
    public int Position { get; set; }
    public int Beaten { get; set; }
    public int Percentage { get; set; }
    public float ReplayPoints { get; set; }
    public int NadeoPoints { get; set; }
    public string ExeBuild { get; set; }
    public string PlayerModel { get; set; }
}