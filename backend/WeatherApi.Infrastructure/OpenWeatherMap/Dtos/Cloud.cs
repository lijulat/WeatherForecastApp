using System.Text.Json.Serialization;

namespace WeatherApi.Infrastructure.OpenWeatherMap.Dtos
{
    public class Cloud
    {
        [JsonPropertyName("all")]
        public int CloudinessPercent { get; set; }
    }

}
