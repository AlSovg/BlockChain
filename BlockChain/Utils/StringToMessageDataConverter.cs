using System.Text.Json;
using System.Text.Json.Serialization;
using BlockChain.Models.Chains;

namespace BlockChain.Utils;

public class StringToMessageDataConverter : JsonConverter<MessageData>
{
    public override MessageData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            string messageString = reader.GetString();

            return new MessageData
            {
                action = messageString, // Используем строку из message
                // ... (инициализация других свойств MessageData значениями по умолчанию)
            };
        }
        else if (reader.TokenType == JsonTokenType.StartObject)
        {
            return JsonSerializer.Deserialize<MessageData>(ref reader, options);
        }

        throw new JsonException("Неверный формат для message");
    }

    public override void Write(Utf8JsonWriter writer, MessageData value, JsonSerializerOptions options)
    {
        throw new NotImplementedException(); // Не реализовано, так как нам нужна только десериализация
    }
}