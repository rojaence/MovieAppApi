namespace MovieAppApi.Models.Converters;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class CustomDateTimeConverter : JsonConverter<DateTime?>
{
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            string dateString = reader.GetString()!;
            if (string.IsNullOrEmpty(dateString))
            {
                return null;
            }
            else
            {
                return DateTime.Parse(dateString);
            }
        }
        else
        {
            // Handle other types if necessary
            throw new JsonException();
        }
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
          writer.WriteStringValue(value.Value.ToString("yyyy-MM-dd"));
        }
        else
        {
          writer.WriteNullValue();
        }
    }
}