namespace MovieAppApi.Converters;

using MovieAppApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

public class KnownForConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return (objectType == typeof(MediaAppearances));
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var knownFor = new MediaAppearances();
        var jArray = JArray.Load(reader);

        foreach (var item in jArray)
        {
          var mediaType = item["media_type"]!.ToString();
            if (mediaType == "movie") // Si tiene la propiedad "title", es un Movie
            {
                var movie = item.ToObject<Movie>(serializer);
                knownFor.Movies.Add(movie!);
            }
            else if (mediaType == "tv") // Si tiene la propiedad "name", es un Tv
            {
                var tv = item.ToObject<Tv>(serializer);
                knownFor.TvSeries.Add(tv!);
            }
        }

        return knownFor;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
