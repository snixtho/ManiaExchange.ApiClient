namespace ManiaExchange.ApiClient.Models.Search;

public class TmxSearchOptions
{
    /// <summary>
    /// Page size - available are: 25 - 100
    /// </summary>
    public int? Limit { get; set; }
    /// <summary>
    /// Page of the search results
    /// </summary>
    public int? Page { get; set; }
}