using ManiaExchange.Api.Enums;

namespace ManiaExchange.Api.Models;

public class IxItemSetInfo
{
    public long ID { get; set; }
    public string Name { get; set; }
    public long UserID { get; set; }
    public string Username { get; set; }
    public string? Description { get; set; }
    public int Downloads { get; set; }
    public TmxEnvironment Collection { get; set; }
    public string CollectionName { get; set; }
    public IxGame Game { get; set; }
    public string GameName { get; set; }
    public int Score { get; set; }
    public string FileName { get; set; }
    public DateTime Uploaded { get; set; }
    public DateTime Updated { get; set; }
    public IxItemInfo[] Items { get; set; }
    public bool Visible { get; set; }
    public bool Unreleased { get; set; }
    public int FileSize { get; set; }
    public int LikeCount { get; set; }
    public int CommentCount { get; set; }
    public string? Tags { get; set; }
    public int ImageCount { get; set; }
}