using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherApi.Domain.WeatherForecasts;
using WeatherApi.Infrastructure.OpenWeatherMap.Dtos;

namespace WeatherApi.Core.WeatherForecasts.Queries
{
    public class GetForecastByZipQuery :GetForecastBase, IRequest<WeatherForecast>
    {
        public GetForecastByZipQuery(string zipcode, string country, string unit): base(country, unit)
        {
            Zipcode = zipcode;           
        }
        public string Zipcode { get; }
    }
}
