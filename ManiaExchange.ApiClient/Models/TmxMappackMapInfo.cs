using ManiaExchange.ApiClient.Enums;
using ManiaExchange.ApiClient.Models;

namespace ManiaExchange.ApiClient.Api.Models;

public class TmxMappackMapInfo : TmxMapInfo
{
    public TmxStatus Status { get; set; }
    public DateTime Added { get; set; }
    public int Position { get; set; }
    public int MappackID { get; set; }
}