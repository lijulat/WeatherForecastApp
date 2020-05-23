using System;
using System.Text.Json.Serialization;

namespace WeatherApi.Domain.WeatherForecasts
{
    public class ForecastDetails
    {
        [JsonPropertyName("forecastDate")]
        public DateTime ForecastDate { get; set; }

        [JsonPropertyName("temperature")]
        public double Temperature { get; set; }

        [JsonPropertyName("humidity")]
        public double Humidity { get; set; }

        [JsonPropertyName("windSpeed")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("weatherIconUrl")]
        public string WeatherIconUrl { get; set; }
    }
}
