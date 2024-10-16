using System.Text.Json.Serialization;

namespace BlockChain.Models.Chains;

public class HashServiceModel
{
    [JsonPropertyName("hash")]
    public string Hash { get; set; }
    
    [JsonPropertyName("data_json")]
    public BlockAction BlockActions { get; set; }
}