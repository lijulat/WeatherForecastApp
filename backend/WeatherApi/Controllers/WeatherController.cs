using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherApi.Core.WeatherForecasts.Queries;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {

        private readonly ILogger<WeatherController> _logger;
        private readonly IMediator _mediator;

        public WeatherController(ILogger<WeatherController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("forecast/city")]
        public async Task<IActionResult> GetForecastByCity([FromQuery] string cityName, [FromQuery] string countryCode = null, [FromQuery] string unit = null)
        {
            var query = new GetForecastByCityQuery(cityName, countryCode, unit);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("forecast/zip")]
        public async Task<IActionResult> GetForecastByZip([FromQuery] string zipCode, [FromQuery] string countryCode = null, [FromQuery] string unit = null)
        {
            var query = new GetForecastByZipQuery(zipCode, countryCode, unit);
            var result = await _mediator.Send(query);
            return Ok(result);

        }
    }
}
