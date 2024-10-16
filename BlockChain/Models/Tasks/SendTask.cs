using System.Text.Json.Serialization;

namespace BlockChain.Models.Tasks;

public class SendTask
{
    [JsonPropertyName("type_task")] public string typeTask { get; set; } = "send_coins";
    
    [JsonPropertyName("from_hach")]
    public string reciever { get; set; } = string.Empty;
    
    [JsonPropertyName("to_hach")]
    public string sender { get; set; } = string.Empty;
}

