namespace MovieAppApi.EnvConfig
{
  using System;
  using System.IO;
  public class DotEnv
  {
    public static void Load()
    {
      var root = Directory.GetCurrentDirectory();
      var filePath = Path.Combine(root, ".env");
      if (!File.Exists(filePath))
      {
        Console.WriteLine("Failed to load .env file");
        return;
      }
      foreach (var line in File.ReadAllLines(filePath))
      {
        var parts = line.Split(
          '=',
          StringSplitOptions.RemoveEmptyEntries
        );
        if (parts.Length != 2)
        {
          continue;
        }
          var key = parts[0];
          var value = parts[1];
          Environment.SetEnvironmentVariable(key, value);
      }
    }
  }
}
