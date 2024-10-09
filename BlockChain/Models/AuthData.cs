using System.Text.Json.Serialization;

namespace BlockChain.Models;

public class AuthData
{
    [JsonPropertyName("username")]
    public string UserName { get; set; } = string.Empty;
    
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
}