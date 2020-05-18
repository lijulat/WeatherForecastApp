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
        public GetForecastByZipcodeHandler(IForecastService forecastService) => _forecastService = forecastService;
        public async Task<WeatherForecast> Handle(GetForecastByZipQuery request, CancellationToken cancellationToken)
                                                    => await _forecastService.GetForecastByZipcode(request.Zipcode, request.Country, request.Unit);
    }
}
