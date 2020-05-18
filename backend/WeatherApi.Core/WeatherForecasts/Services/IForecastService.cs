using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Domain.WeatherForecasts;

namespace WeatherApi.Core.WeatherForecasts.Services
{
    public interface IForecastService
    {
        Task<WeatherForecast> GetForecastByZipcode(string zipcode, string country, string unit);

        Task<WeatherForecast> GetForecastByCity(string city, string country, string unit);
    }
}
