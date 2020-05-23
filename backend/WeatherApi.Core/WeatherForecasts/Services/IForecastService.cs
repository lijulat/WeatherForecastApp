using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApi.Domain.WeatherForecasts;
using WeatherApi.Infrastructure.OpenWeatherMap.Dtos;

namespace WeatherApi.Core.WeatherForecasts.Services
{
    public interface IForecastService
    {
        Task<WeatherForecast> GetForecast(Func<string, string, string, Task<WeatherForecastResponse>> forecastFunc,
                                          Func<string, string, string, Task<CurrentWeatherResponse>> currentWeatherFunc,
                                          string query,
                                          string country,
                                          string unit);
    }
}
