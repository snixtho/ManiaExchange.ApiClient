namespace ManiaExchange.ApiClient.Api.Models;

public class TmxMapObject
{
    public string ObjectPath { get; set; }
    public string ObjectAuthor { get; set; }
    public string Name { get; set; }
    public bool OnIX { get; set; }
    public long? UserID { get; set; }
    public string? Username { get; set; }
}