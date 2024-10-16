using System.Text.Json.Serialization;

namespace BlockChain.Models.Chains;

public class HashData
{
    [JsonPropertyName("hach_version_file")]
    public string version { get; set; }
    
    [JsonPropertyName("user_hash")]
    public string user { get; set; }
}