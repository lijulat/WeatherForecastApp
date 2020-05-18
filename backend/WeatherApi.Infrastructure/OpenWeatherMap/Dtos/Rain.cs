using System.Text.Json.Serialization;

namespace WeatherApi.Infrastructure.OpenWeatherMap.Dtos
{
    public class Rain
    {
        [JsonPropertyName("3h")]
        public float Volume { get; set; }
    }    

}
