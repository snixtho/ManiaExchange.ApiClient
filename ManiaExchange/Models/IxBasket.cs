namespace ManiaExchange.Api.Models;

public class IxBasket
{
    public long BasketUserId { get; set; }
    public string BasketUsername { get; set; } = string.Empty;
    public int FileSize { get; set; }
    public IEnumerable<IxItemInfo> Items { get; set; } = Array.Empty<IxItemInfo>();
    public DateTime LastChanged { get; set; }
}