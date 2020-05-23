using System.Text.Json.Serialization;

namespace WeatherApi.Infrastructure.OpenWeatherMap.Dtos
{
    public class Wind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        [JsonPropertyName("deg")]
        public int Direction { get; set; }
    }

}
