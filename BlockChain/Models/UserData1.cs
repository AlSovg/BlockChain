using System.Text.Json.Serialization;
using BlockChain.Models.Tasks;

namespace BlockChain.Models;

public class UserData1 : AuthData
{
    [JsonPropertyName("user_hash")]
    public string user_hash { get; set; } = string.Empty;
    
    [JsonPropertyName("version")]
    public string hach_version_file { get; set; } = string.Empty;
    
    [JsonPropertyName("data")]
    public SendTask data { get; set; }
}