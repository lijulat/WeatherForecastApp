using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApi.Core.WeatherForecasts.Queries
{
    public class GetForecastByZipcodeValidator : AbstractValidator<GetForecastByZipQuery>
    {
        public GetForecastByZipcodeValidator()
        {
            RuleFor(v => v.Zipcode)
                .NotEmpty();
        }

    }
}
