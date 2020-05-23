using System.Text.Json.Serialization;

namespace WeatherApi.Infrastructure.OpenWeatherMap.Dtos
{
    public class WeatherCondition
    {
        [JsonPropertyName("temp")]
        public double Temperature { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        public double MinTemp { get; set; }

        [JsonPropertyName("temp_max")]
        public double MaxTemp { get; set; }

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("sea_level")]
        public int SeaLevel { get; set; }

        [JsonPropertyName("grnd_level")]
        public int GroundLevel { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("temp_kf")]
        public double InternalParam { get; set; }
    }

}
