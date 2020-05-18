using System;

namespace WeatherApi.Domain.WeatherForecasts
{
    public class ForecastDetails
    {
        public DateTime ForecastDate { get; set; }

        public float Temperature { get; set; }

        public float Humidity { get; set; }

        public float WindSpeed { get; set; }

        public string WeatherIconUrl { get; set; }
    }
}
