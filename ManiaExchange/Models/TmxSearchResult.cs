namespace ManiaExchange.Api.Models;

public class TmxSearchResult<T>
{
    public T[] Results { get; set; }
    public int TotalItemCount { get; set; }
}