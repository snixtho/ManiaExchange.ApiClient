
using ManiaExchange.ApiClient;

var api = new MxTmApi(".NET ManiaExchange.ApiClient Example");

api.SetCacheTime(TimeSpan.FromSeconds(10));

var search = await api.SearchMapsAsync(filter =>
{
    filter.Tags = new[] {2};
});

foreach (var result in search.Results)
    Console.WriteLine(result.Name);
