using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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
        
        private readonly IMapper _mapper;
        private readonly OpenWeatherMapConfig _config;
        public ForecastService(OpenWeatherMapConfig config, IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
        }

        public async Task<WeatherForecast> GetForecast(Func<string, string, string, Task<WeatherForecastResponse>> forecastFunc,
                                                       Func<string, string, string, Task<CurrentWeatherResponse>> currentWeatherFunc, 
                                                       string query, 
                                                       string country, 
                                                       string unit)
        {
            var weatherForecastResponse = await forecastFunc(query, country, unit);

            if (weatherForecastResponse is null) return null;

            var forecast = _mapper.Map<WeatherForecast>(weatherForecastResponse);

            if (forecast is null) return null;

            var currentWeatherResponse = await currentWeatherFunc(query, country, unit);

            if (currentWeatherResponse is CurrentWeatherResponse)
            {
                var currentForecast = _mapper.Map<ForecastDetails>(currentWeatherResponse);
                if( currentForecast is ForecastDetails)
                {
                    forecast.DailyForecasts?.Insert(0, currentForecast);
                }
                
            }

            if (forecast.DailyForecasts.Count is int count && count == 0) return null;

            // transform into average
            return new WeatherForecast
            {
                City = forecast.City,
                Country = forecast.Country,
                DailyForecasts = forecast.DailyForecasts?.GroupBy(group => group.ForecastDate)
                                                        .Select(group => new ForecastDetails()
                                                        {
                                                            ForecastDate = group.Key,
                                                            Temperature = group.Average(forecast => forecast.Temperature),
                                                            Humidity = group.Average(forecast => forecast.Humidity),
                                                            WindSpeed = group.Average(forecast => forecast.WindSpeed),
                                                            WeatherIconUrl = string.Format(_config.IconUrl, group.FirstOrDefault()?.WeatherIconUrl)
                                                        }).ToList()
            };            
        }
    }
}
