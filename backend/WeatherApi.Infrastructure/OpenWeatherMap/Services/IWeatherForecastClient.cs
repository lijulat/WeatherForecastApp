using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApi.Infrastructure.OpenWeatherMap.Dtos;

namespace WeatherApi.Infrastructure.OpenWeatherMap.Services
{
    public interface IWeatherForecastClient
    {
        Task<WeatherForecastResponse> GetForecastByZipcode(string zipcode, string country, string unit);
        Task<WeatherForecastResponse> GetForecastByCity(string city, string country, string unit);
        Task<CurrentWeatherResponse> GetCurrentWeatherByZipcode(string zipcode, string country, string unit);
        Task<CurrentWeatherResponse> GetCurrentWeatherByCity(string city, string country, string unit);
    }
}
