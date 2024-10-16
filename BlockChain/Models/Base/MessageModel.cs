using System.Text.Json.Serialization;

namespace BlockChain.Models.Base;

public class MessageModel
{
    [JsonPropertyName("message")]
    public string Message { get; set; }
    
    [JsonPropertyName("success")]
    public bool Success { get; set; }
}

public class SuccessMessageModel : MessageModel
{
    public SuccessMessageModel()
    {
        Success = true;
    }
} 
public class FailMessageModel : MessageModel
{
    public FailMessageModel()
    {
        Success = false;
    }
} 


