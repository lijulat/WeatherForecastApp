using System.Collections.Generic;
using System.Text;

namespace WeatherApi.Domain.WeatherForecasts
{
    public class WeatherForecast
    {
        public string City { get; set; }

        public string Country { get; set; }

        public List<ForecastDetails> DailyForecasts { get; set; }
    }
}
