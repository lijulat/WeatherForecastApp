using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using WeatherApi.Core.Helpers;
using WeatherApi.Domain.WeatherForecasts;
using WeatherApi.Infrastructure.OpenWeatherMap;
using WeatherApi.Infrastructure.OpenWeatherMap.Dtos;

namespace WeatherApi.Core.WeatherForecasts.Mappers
{
    public static class DomainExtensions
    {
        public static WeatherForecast ToWeatherForecast(this WeatherForecastResponse weatherForecastResponse, OpenWeatherMapConfig config)
        {
            var dailyForecasts = weatherForecastResponse.ForecastData.GroupBy(forecasts => forecasts.DateUnixFormat.ToDateTime().Date)
                                                            .Select(group => new ForecastDetails()
                                                            {
                                                                ForecastDate = group.Key,
                                                                Temperature = group.Average(forecast => forecast.WeatherInfo.Temperature),
                                                                Humidity = group.Average(forecast => forecast.WeatherInfo.Humidity),
                                                                WindSpeed = group.Average(forecast => forecast.WindData.Speed),
                                                                WeatherIconUrl = string.Format(config.IconUrl, group.FirstOrDefault()?.WeatherData.FirstOrDefault()?.Icon)
                                                            }).ToList();

            return new WeatherForecast
            {
                City = weatherForecastResponse.CityData.Name,
                Country = weatherForecastResponse.CityData.Country,
                DailyForecasts = dailyForecasts
            };
        }

        public static ForecastDetails ToWeatherForecast(this CurrentWeatherResponse currentWeatherResponse, OpenWeatherMapConfig config)
        {
            return new ForecastDetails
            {
                ForecastDate = currentWeatherResponse.DateUnixFormat.ToDateTime().Date,
                Temperature = currentWeatherResponse.WeatherInfo.Temperature,
                Humidity = currentWeatherResponse.WeatherInfo.Humidity,
                WindSpeed = currentWeatherResponse.WindData.Speed,
                WeatherIconUrl = string.Format(config.IconUrl, currentWeatherResponse.WeatherData.FirstOrDefault()?.Icon)
            };
        }
    }
}
