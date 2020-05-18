using System.Text.Json.Serialization;

namespace WeatherApi.Infrastructure.OpenWeatherMap.Dtos
{
    public class Sys
    {
        [JsonPropertyName("pod")]
        public string Pod { get; set; }
    }

}
