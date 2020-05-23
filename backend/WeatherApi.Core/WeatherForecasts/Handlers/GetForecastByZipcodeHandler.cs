using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherApi.Core.WeatherForecasts.Mappers;
using WeatherApi.Core.WeatherForecasts.Queries;
using WeatherApi.Core.WeatherForecasts.Services;
using WeatherApi.Domain.WeatherForecasts;
using WeatherApi.Infrastructure.OpenWeatherMap.Services;

namespace WeatherApi.Core.WeatherForecasts.Handlers
{
    public class GetForecastByZipcodeHandler : IRequestHandler<GetForecastByZipQuery, WeatherForecast>
    {
        private readonly IForecastService _forecastService;

        private readonly IWeatherForecastClient _weatherClient;

        public GetForecastByZipcodeHandler(IForecastService forecastService, IWeatherForecastClient weatherClient)
        {
            _forecastService = forecastService;
            _weatherClient = weatherClient;
        }
        public async Task<WeatherForecast> Handle(GetForecastByZipQuery request, CancellationToken cancellationToken)
                                                    => await _forecastService.GetForecast(_weatherClient.GetForecastByZipcode,
                                                                                          _weatherClient.GetCurrentWeatherByCity,
                                                                                           request.Zipcode,
                                                                                           request.Country,
                                                                                           request.Unit
                                                                                         );
    }
}
