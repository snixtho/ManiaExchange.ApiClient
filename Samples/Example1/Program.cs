
using ManiaExchange.Api;

var api = new TmxTm2Api("Evo Bot");

var search = await api.SearchMapsAsync(options =>
{
    options.TrackName = new[] {"forgotten"};
});

Console.WriteLine(search);
