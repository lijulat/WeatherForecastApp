using System.Text.Json.Serialization;

namespace WeatherApi.Infrastructure.OpenWeatherMap.Dtos
{
    public class CurrentWeatherSys
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }        

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("sunrise")]
        public int Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public int Sunset { get; set; }
    }

}
