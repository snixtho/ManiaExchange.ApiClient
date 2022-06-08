
using ManiaExchange.Api;

var api = new TmxTmApi("Evo Bot");

var search = await api.SearchMapsAsync();

foreach (var map in search.Results)
    Console.WriteLine(map.Name);
