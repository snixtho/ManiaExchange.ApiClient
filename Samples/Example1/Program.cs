
using ManiaExchange.Api;

var api = new MxTmApi("Evo Bot");

var search = await api.SearchMapsAsync(filter =>
{
    filter.Tags = new[] {2};
});

foreach (var result in search.Results)
    Console.WriteLine(result.Name);
