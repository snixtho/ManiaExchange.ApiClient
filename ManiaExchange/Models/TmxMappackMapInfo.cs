using ManiaExchange.Api.Enums;
using ManiaExchange.Api.Models;

namespace ManiaExchange.Api.Api.Models;

public class TmxMappackMapInfo : TmxMapInfo
{
    public TmxStatus Status { get; set; }
    public DateTime Added { get; set; }
    public int Position { get; set; }
    public int MappackID { get; set; }
}