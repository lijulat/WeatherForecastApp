using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WeatherApi.Infrastructure.OpenWeatherMap.Dtos
{
    public class CurrentWeatherResponse
    {
        [JsonPropertyName("cod")]
        public string Code { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("coord")]
        public Coordinates Coordinates { get; set; }

        [JsonPropertyName("dt")]
        public int DateUnixFormat { get; set; }

        [JsonPropertyName("base")]
        public string Base { get; set; }

        [JsonPropertyName("main")]
        public WeatherCondition WeatherInfo { get; set; }

        [JsonPropertyName("clouds")]
        public Cloud CloudData { get; set; }

        [JsonPropertyName("wind")]
        public Wind WindData { get; set; }

        [JsonPropertyName("sys")]
        public CurrentWeatherSys SysData { get; set; }

        [JsonPropertyName("weather")]
        public WeatherResponse[] WeatherData { get; set; }

    }
}
