using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherApi.Domain.WeatherForecasts;

namespace WeatherApi.Core.WeatherForecasts.Queries
{
    public class GetForecastByCityQuery: GetForecastBase, IRequest<WeatherForecast>
    {
        public GetForecastByCityQuery(string city, string country, string unit) : base(country, unit)
        {
            City = city;
        }
        public string City { get; }
    }
}
