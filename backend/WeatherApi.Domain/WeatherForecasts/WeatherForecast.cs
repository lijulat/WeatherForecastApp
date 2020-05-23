using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WeatherApi.Domain.WeatherForecasts
{
    public class WeatherForecast
    {
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("dailyForecasts")]
        public List<ForecastDetails> DailyForecasts { get; set; }
    }
}
