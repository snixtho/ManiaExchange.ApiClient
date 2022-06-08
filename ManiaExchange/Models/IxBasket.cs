using ManiaExchange.Api.Enums;

namespace ManiaExchange.Api.Models;

public class IxBasket
{
    public long BasketUserID { get; set; }
    public string BasketUsername { get; set; }
    public int FileSize { get; set; }
    public IEnumerable<IxItemInfo> Items { get; set; }
    public DateTime LastChanged { get; set; }
}