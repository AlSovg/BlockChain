using System.Text.Json.Serialization;

namespace BlockChain.Models.Chains;

public class ServiceResponseModel
{
    [JsonPropertyName("success")]
    public bool Status { get; set; }
    
    [JsonPropertyName("chains")]
    public ActiveBlock ActiveBlock { get; set; }
}