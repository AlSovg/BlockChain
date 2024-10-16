using System.Text.Json.Serialization;

namespace BlockChain.Models.Chains;

public class ActiveBlock
{
    [JsonPropertyName("block_active")]
    public List<Block> Blocks { get; set; }
    
    [JsonPropertyName("users_block")]
    public List<User> Users { get; set; }
}