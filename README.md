# ManiaExchange API Client

General purpose API client for [ManiaExchange](https://mania.exchange/). The library implements a client wrapper for the version of ManiaExchange's API (v2) as defined [here](https://api2.mania.exchange/).

# Usage
The library exposes classes for each of MX's websites:
- `IxApi`: [Item Exchange API](https://api2.mania.exchange/search?s=5)
- `TmxSmApi`: [ShootMania Exchange API](https://api2.mania.exchange/search?s=3)
- `TmxTm2Api`: [TrackMania 2 Exchange API](https://api2.mania.exchange/search?s=1)
- `TmxTmApi`: [TrackMania 2020 Exchange API](https://api2.mania.exchange/search?s=2)

## Example basic usage
```csharp
using ManiaExchange.Api;

// instanitate the API class, pass a user agent to the constructor
var api = new TmxTmApi("My MX Client");

// call an api endpoint, in this case: /api/tags/gettags
var tags = await api.GetTagsAsync();

// the method returns a C# native object parsed from the response
foreach (var tag in tags)
{
    Console.WriteLine(tag.Name);
}
```

# Documentation
Since all the methods have an almost direct 1:1 mapping to the original API as defined at [api2.mania.exchange](https://api2.mania.exchange/) you can use this website as a reference. The methods are categorized into their respective classes. All the methods and objects are also commented with the same documentation on the MX API docs website for your convenience.

# Issues
This project is not affiliated with ManiaExchange, so for issues related to the API itself, please refer to the [ManiaExchange API documentation website](https://api2.mania.exchange/) or ManiaExchange's support channel.

For issues related to the client and library itself, feel free to open an issue in this repository.