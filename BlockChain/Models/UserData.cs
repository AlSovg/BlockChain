using System.Text.Json.Serialization;

namespace BlockChain.Models;

public class UserData : AuthData
{
    [JsonPropertyName("user_hash")]
    public string user_hash { get; set; } = string.Empty;
    
    [JsonPropertyName("hach_version_file")]
    public string hach_version_file { get; set; } = string.Empty;
}
