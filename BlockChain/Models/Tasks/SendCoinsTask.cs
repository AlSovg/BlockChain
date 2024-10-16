using System.Text.Json.Serialization;

namespace BlockChain.Models.Tasks;

public class SendCoinsTask : SendTask
{
    [JsonPropertyName("count_coins")]
    public int coinsCount { get; set; }
}