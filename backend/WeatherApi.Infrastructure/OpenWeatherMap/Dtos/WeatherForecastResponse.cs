using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WeatherApi.Infrastructure.OpenWeatherMap.Dtos
{
    public class WeatherForecastResponse
    {
        [JsonPropertyName("cod")]
        public string Code { get; set; }

        [JsonPropertyName("message")]
        public int Message { get; set; }

        [JsonPropertyName("cnt")]
        public int Count { get; set; }

        [JsonPropertyName("list")]
        public ForecastResponse[] ForecastData { get; set; }

        [JsonPropertyName("city")]
        public City CityData { get; set; }
    }
}
