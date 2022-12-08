using System.Text.Json.Serialization;
using Hawf.Json.Converters;

namespace ManiaExchange.ApiClient.Models;

public class TmxMapInfo
{
    public long TrackID { get; set; }
    public long MapID { get; set; }
    public long UserID { get; set; }
    public string Username { get; set; }
    public string GbxMapName { get; set; }
    public string AuthorLogin { get; set; }
    public string MapType { get; set; }
    public string TitlePack { get; set; }
    public string TrackUID { get; set; }
    public string Mood { get; set; }
    public int DisplayCost { get; set; }
    public string ModName { get; set; }
    public int LightMap { get; set; }
    public string ExeVersion { get; set; }
    public string ExeBuild { get; set; }
    public int AuthorTime { get; set; }
    public int ParserVersion { get; set; }
    public string UploadedAt { get; set; }
    public string UpdatedAt { get; set; }
    public string Name { get; set; }
    [JsonConverter(typeof(StringToIntArrayConverter))]
    public int[]? Tags { get; set; }
    public string TypeName { get; set; }
    public string StyleName { get; set; }
    public string EnvironmentName { get; set; }
    public string VehicleName { get; set; }
    public bool UnlimitedRequired { get; set; }
    public string RouteName { get; set; }
    public string LengthName { get; set; }
    public string DifficultyName { get; set; }
    public int Laps { get; set; }
    public long? ReplayWRID { get; set; }
    public int? ReplayWRTime { get; set; }
    public long? ReplayWRUserID { get; set; }
    public string ReplayWRUsername { get; set; }
    public int TrackValue { get; set; }
    public string Comments { get; set; }
    public int MappackID { get; set; }
    public bool Unlisted { get; set; }
    public bool Unreleased { get; set; }
    public bool Downloadable { get; set; }
    public int RatingVoteCount { get; set; }
    public float RatingVoteAverage { get; set; }
    public bool HasScreenshot { get; set; }
    public bool HasThumbnail { get; set; }
    public int EmbeddedObjectsCount { get; set; }
    public int EmbeddedItemsSize { get; set; }
    public bool IsMP4 { get; set; }
    public bool SizeWarning { get; set; }
}