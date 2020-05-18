using System.Text.Json.Serialization;

namespace WeatherApi.Infrastructure.OpenWeatherMap.Dtos
{
    public class ForecastResponse
    {
        [JsonPropertyName("dt")]
        public int DateUnixFormat { get; set; }

        [JsonPropertyName("main")]
        public WeatherCondition WeatherInfo { get; set; }

        [JsonPropertyName("weather")]
        public WeatherResponse[] WeatherData { get; set; }

        [JsonPropertyName("clouds")]
        public Cloud CloudData { get; set; }

        [JsonPropertyName("wind")]
        public Wind WindData { get; set; }

        [JsonPropertyName("sys")]
        public Sys SysData { get; set; }

        [JsonPropertyName("dt_txt")]
        public string DateIsoFormat { get; set; }

        [JsonPropertyName("rain")]
        public Rain RainData { get; set; }
    }

}
