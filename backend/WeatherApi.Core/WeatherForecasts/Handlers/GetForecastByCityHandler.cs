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
    public class GetForecastByCityHandler : IRequestHandler<GetForecastByCityQuery, WeatherForecast>
    {
        private readonly IForecastService _forecastService;
        public GetForecastByCityHandler(IForecastService forecastService) => _forecastService = forecastService;
        public async Task<WeatherForecast> Handle(GetForecastByCityQuery request, CancellationToken cancellationToken)
                                                    => await _forecastService.GetForecastByCity(request.City, request.Country, request.Unit);
    }
}
