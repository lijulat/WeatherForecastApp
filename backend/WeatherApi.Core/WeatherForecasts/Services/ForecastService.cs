using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherApi.Core.Helpers;
using WeatherApi.Core.WeatherForecasts.Mappers;
using WeatherApi.Domain.WeatherForecasts;
using WeatherApi.Infrastructure.OpenWeatherMap;
using WeatherApi.Infrastructure.OpenWeatherMap.Dtos;
using WeatherApi.Infrastructure.OpenWeatherMap.Services;

namespace WeatherApi.Core.WeatherForecasts.Services
{
    public class ForecastService : IForecastService
    {
        private readonly IWeatherForecastClient _weatherClient;

        private readonly OpenWeatherMapConfig _config;
        public ForecastService(IWeatherForecastClient weatherClient, OpenWeatherMapConfig config)
        {
            _weatherClient = weatherClient;
            _config = config;
        }

        public async Task<WeatherForecast> GetForecastByCity(string city, string country, string unit)
                                                => await GetForecast(_weatherClient.GetForecastByCity, _weatherClient.GetCurrentWeatherByCity, city, country, unit);

        public async Task<WeatherForecast> GetForecastByZipcode(string zipcode, string country, string unit)
                                                => await GetForecast(_weatherClient.GetForecastByZipcode, _weatherClient.GetCurrentWeatherByZipcode, zipcode, country, unit);

        public async Task<WeatherForecast> GetForecast(Func<string, string, string, Task<WeatherForecastResponse>> forecastFunc,
                                                                Func<string, string, string, Task<CurrentWeatherResponse>> currentWeatherFunc, string query, string country, string unit)
        {
            var weatherForecastResponse = await forecastFunc(query, country, unit);

            var forecast = weatherForecastResponse?.ToWeatherForecast(_config);

            if (forecast?.DailyForecasts.Count < 6)
            {
                var currentWeatherResponse = await currentWeatherFunc(query, country, unit);

                if (currentWeatherResponse.DateUnixFormat.ToDateTime().IsTodaysDate() && currentWeatherResponse is object)
                {
                    forecast.DailyForecasts.Insert(0, currentWeatherResponse.ToWeatherForecast(_config));
                }
            }
            return forecast;
        }
    }
}
