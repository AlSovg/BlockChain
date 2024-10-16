using System.Text.Json.Serialization;

namespace BlockChain.Models;

public class CoinsCountModel
{
    [JsonPropertyName("success")]
    public bool Status { get; set; }
    
    [JsonPropertyName("message")]
    public string Message { get; set; }
    
    [JsonPropertyName("coins")]
    public int Coins { get; set; }
}