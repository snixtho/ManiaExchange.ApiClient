using ManiaExchange.ApiClient.Enums;

namespace ManiaExchange.ApiClient.Models;

public class IxItemInfo
{
    public long ID { get; set; }
    public string Name { get; set; }
    public long UserID { get; set; }
    public string Username { get; set; }
    public string? Description { get; set; }
    public string? AuthorLogin { get; set; }
    public string? OriginalBlock { get; set; }
    public IxItemType Type { get; set; }
    public string TypeName { get; set; }
    public int Downloads { get; set; }
    public TmxEnvironment Collection { get; set; }
    public string CollectionName { get; set; }
    public int Game { get; set; }
    public string GameName { get; set; }
    public int Score { get; set; }
    public string FileName { get; set; }
    public DateTime Uploaded { get; set; }
    public DateTime Updated { get; set; }
    public long SetID { get; set; }
    public string? SetName { get; set; }
    public string? Directory { get; set; }
    public string? ZipIndex { get; set; }
    public bool Visible { get; set; }
    public bool Unlisted { get; set; }
    public bool Unreleased { get; set; }
    public int LikeCount { get; set; }
    public int CommentCount { get; set; }
    public int FileSize { get; set; }
    public string? Tags { get; set; }
    public bool HasTumbnail { get; set; }
}