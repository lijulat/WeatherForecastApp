using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApi.Core.WeatherForecasts.Queries
{
    public class GetForecastByCityValidator : AbstractValidator<GetForecastByCityQuery>
    {
        public GetForecastByCityValidator()
        {
            RuleFor(v => v.City)
                .NotEmpty();
        }

    }
}
