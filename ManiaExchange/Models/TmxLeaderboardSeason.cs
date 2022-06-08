namespace ManiaExchange.Api.Models;

public class TmxLeaderboardSeason
{
    public int SeasonID { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}