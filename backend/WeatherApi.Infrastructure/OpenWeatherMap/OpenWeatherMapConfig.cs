using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApi.Infrastructure.OpenWeatherMap
{
    public class OpenWeatherMapConfig
    {
        public string ApiBaseUrl { get; set;}
        public string ForecastRoute { get; set; }
        public string CurrentWeatherRoute { get; set; }
        public string ApiKey { get; set; }
        public string DefaultCountryCode { get; set; }
        public string IconUrl { get; set; }
        public int RetryCount { get; set; }
        public int TimoutSeconds { get; set; }

    }
}
