using System;
using System.Collections.Generic;
using System.Text;
using WeatherApi.Infrastructure.OpenWeatherMap.Dtos;

namespace WeatherApi.IntegrationTests
{
    public static class TestHelper
    {
        public static WeatherForecastResponse MockWeatherForecastResponse =>
                                                        new WeatherForecastResponse()
                                                        {
                                                            CityData = new City { Name = "Hamburg", Country = "DE" },
                                                            ForecastData = new ForecastResponse[] 
                                                            {
                                                                new ForecastResponse 
                                                                {
                                                                    DateUnixFormat = 1590559200,
                                                                    WeatherInfo = new WeatherCondition 
                                                                    {
                                                                        Temperature = 69.55,
                                                                        Humidity = 50
                                                                    },
                                                                    WindData = new Wind() { Speed = 9.53 },
                                                                    WeatherData = new WeatherResponse[] 
                                                                    { 
                                                                        new WeatherResponse { Icon = "04d" } 
                                                                    }
                                                                }
                                                            }
                                                        };

        public static string InvalidCity => "_invalidCity";

        public static string InvalidZip => "_invalidZip";


    }
}
