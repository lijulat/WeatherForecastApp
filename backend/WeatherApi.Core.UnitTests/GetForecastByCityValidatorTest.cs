using FluentValidation;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherApi.Core.WeatherForecasts.Queries;

namespace WeatherApi.Core.UnitTests
{
    [TestClass]
    public class GetForecastByCityValidatorTest
    {
        [TestMethod]
        public void Should_Not_Have_Validation_Error_If_City_Is_Not_Empty()
        {
            var validator = new GetForecastByCityValidator();
            var model = new GetForecastByCityQuery("Hamburg", null, null);            
            var result = validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.City);
        }

        [TestMethod]
        public void Should_Have_Validation_Error_If_City_Is_Empty()
        {
            var validator = new GetForecastByCityValidator();
            var model = new GetForecastByCityQuery("", null, null);
            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.City)
                               .WithErrorMessage("'City' must not be empty.")
                               .WithSeverity(Severity.Error)
                               .WithErrorCode("NotEmptyValidator");
        }

        [TestMethod]
        public void Should_Have_Validation_Error_If_City_Is_Null()
        {
            var validator = new GetForecastByCityValidator();
            var model = new GetForecastByCityQuery(null, null, null);
            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.City)
                               .WithErrorMessage("'City' must not be empty.")
                               .WithSeverity(Severity.Error)
                               .WithErrorCode("NotEmptyValidator");
        }
    }
}
