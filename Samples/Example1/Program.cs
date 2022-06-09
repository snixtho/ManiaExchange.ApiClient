
using ManiaExchange.Api;

var api = new TmxTmApi("Evo Bot");

var tags = await api.GetTagsAsync();

foreach (var tag in tags)
{
    Console.WriteLine(tag.Name);
}