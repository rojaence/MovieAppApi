namespace MovieAppApi.Services;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class JsonSerializationConfig
{
  public static readonly JsonSerializerOptions DefaultOptions = new()
  {
    PropertyNamingPolicy = new SnakeCaseToCamelCaseNamingPolicy(),
  };
}

public class SnakeCaseToCamelCaseNamingPolicy : JsonNamingPolicy
{
  public override string ConvertName(string name)
  {
    return ConvertSnakeCaseToCamelCase(name);
  }

  private static string ConvertSnakeCaseToCamelCase(string name)
  {
    if (string.IsNullOrEmpty(name))
    {
      return name;
    }
    var parts = name.Split('_');
    var result = parts[0];

    for (int i = 1; i < parts.Length; i++)
    {
        result += char.ToUpper(parts[i][0]) + '-' + parts[i][1..];
    }

    return result;
  }
}