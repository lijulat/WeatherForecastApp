using System.Text.Json.Serialization;

namespace WeatherApi.Infrastructure.OpenWeatherMap.Dtos
{
    public class Coordinates
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lon")]
        public double Lon { get; set; }
    }   

}
