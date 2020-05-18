using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WeatherApi.Core.WeatherForecasts.Queries
{
    public abstract class GetForecastBase
    {
        protected GetForecastBase(string country, string unit)
        {
            Country = country;
            Unit = unit;
        }
        public string Country { get; }

        public string Unit { get; }
    }
}
