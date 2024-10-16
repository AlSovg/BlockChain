using System.Text.Json.Serialization;

namespace BlockChain.Models.Chains;

public class User
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("curlid")]
    public string curlId { get; set; }
    
    [JsonPropertyName("hach")]
    public string hash { get; set; }
    
    [JsonPropertyName("coins")]
    public int CoinsCollected { get; set; }
}