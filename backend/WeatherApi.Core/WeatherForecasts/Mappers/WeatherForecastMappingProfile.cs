using AutoMapper;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using WeatherApi.Domain.WeatherForecasts;
using WeatherApi.Infrastructure.OpenWeatherMap.Dtos;
using WeatherApi.Core.Helpers;

namespace WeatherApi.Core.WeatherForecasts.Mappers
{
    public class WeatherForecastMappingProfile: Profile
    {
        public WeatherForecastMappingProfile()
        {
            CreateMap<WeatherForecastResponse, WeatherForecast>()
                .ForMember(dest => dest.City, map => map.MapFrom(src => src.CityData.Name))
                .ForMember(dest => dest.Country, map => map.MapFrom(src => src.CityData.Country))
                .ForMember(dest => dest.DailyForecasts, map => map.MapFrom(src => src.ForecastData));

            CreateMap<ForecastResponse, ForecastDetails>()
                .ForMember(dest => dest.ForecastDate, map => map.MapFrom(src => src.DateUnixFormat.ToDateTime().Date))
                .ForMember(dest => dest.Temperature, map => map.MapFrom(src => src.WeatherInfo.Temperature))
                .ForMember(dest => dest.Humidity, map => map.MapFrom(src => src.WeatherInfo.Humidity))
                .ForMember(dest => dest.WindSpeed, map => map.MapFrom(src => src.WindData.Speed))
                .ForMember(dest => dest.WeatherIconUrl, map => map.MapFrom(src => src.WeatherData.FirstOrDefault().Icon));
            

            CreateMap<CurrentWeatherResponse, ForecastDetails>()
                .ForMember(dest => dest.ForecastDate, map => map.MapFrom(src => src.DateUnixFormat.ToDateTime().Date))
                .ForMember(dest => dest.Temperature, map => map.MapFrom(src => src.WeatherInfo.Temperature))
                .ForMember(dest => dest.Humidity, map => map.MapFrom(src => src.WeatherInfo.Humidity))
                .ForMember(dest => dest.WindSpeed, map => map.MapFrom(src => src.WindData.Speed))
                .ForMember(dest => dest.WeatherIconUrl, map => map.MapFrom(src => src.WeatherData.FirstOrDefault().Icon));
        }
    }
}
