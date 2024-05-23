namespace MovieAppApi.Models.Converters;

using System;
/* using System.Text.Json;
using System.Text.Json.Serialization; */
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/* public class CustomDateTimeConverter : JsonConverter<DateTime?>
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
} */

public class NullableDateTimeConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(DateTime?) || objectType == typeof(DateTime);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.String)
        {
            var value = reader.Value!.ToString();
            if (string.IsNullOrEmpty(value) || existingValue?.ToString() == "")
            {
                return null!; // Devuelve null si la cadena está vacía
            }

            if (DateTime.TryParse(value, out DateTime date))
            {
                return date; // Devuelve la fecha convertida
            }
        }

        if (reader.TokenType == JsonToken.Null)
        {
            return null!;
        }

        throw new JsonSerializationException("Unable to convert value to DateTime.");
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is DateTime dateTime && value.ToString() != "")
        {
            writer.WriteValue(dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));
        }
        else
        {
            writer.WriteNull(); // Escribe null si el valor es null
        }
    }
}