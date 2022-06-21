namespace ManiaExchange.ApiClient.Models.Search;

public class TmxSearchResult<T>
{
    public T[] Results { get; set; }
    public int TotalItemCount { get; set; }
}