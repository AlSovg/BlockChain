using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json.Serialization;

namespace BlockChain.Utils;

public class GetPropertyName
{
    public string GetDisplayName()
    {
        var memberInfo = this.GetType().GetMember(this.ToString());
        var displayAttribute = memberInfo[0].GetCustomAttribute<DisplayAttribute>();
        return displayAttribute?.Name ?? this.ToString();
    }

    public string GetJsonPropertyName()
    {
        var memberInfo = this.GetType().GetMember(this.ToString());
        var jsonPropertyAttribute = memberInfo[0].GetCustomAttribute<JsonPropertyNameAttribute>();
        return jsonPropertyAttribute?.Name ?? this.ToString();
    }
}