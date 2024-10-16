using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlockChain.Utils;

public class StringConverter : JsonConverter<string>
{
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            // Проверяем, что значение в пределах диапазона long 
            if (reader.TryGetInt64(out long longValue)) 
            {
                return longValue.ToString(); // Преобразуем число в строку
            }
            else
            {
                return "0";
            }
        }
        else if (reader.TokenType == JsonTokenType.String)
        {
            return reader.GetString(); // Читаем строку
        }
        else
        {
            throw new JsonException($"Неверный тип для count_coins: ожидается число или строка, а получено {reader.TokenType}.");
        }
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        throw new NotImplementedException(); // Не реализовано, так как нам нужна только десериализация
    }
    
}