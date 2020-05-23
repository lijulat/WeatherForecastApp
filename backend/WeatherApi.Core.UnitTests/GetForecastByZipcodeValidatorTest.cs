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
    public class GetForecastByZipcodeValidatorTest
    {
        [TestMethod]
        public void Should_Not_Have_Validation_Error_If_Zip_Is_Not_Empty()
        {
            var validator = new GetForecastByZipcodeValidator();
            var model = new GetForecastByZipQuery("20095", null, null);            
            var result = validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Zipcode);
        }

        [TestMethod]
        public void Should_Have_Validation_Error_If_Zipcode_Is_Empty()
        {
            var validator = new GetForecastByZipcodeValidator();
            var model = new GetForecastByZipQuery("", null, null);
            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Zipcode)
                               .WithErrorMessage("'Zipcode' must not be empty.")
                               .WithSeverity(Severity.Error)
                               .WithErrorCode("NotEmptyValidator");
        }

        [TestMethod]
        public void Should_Have_Validation_Error_If_Zipcode_Is_Null()
        {
            var validator = new GetForecastByZipcodeValidator();
            var model = new GetForecastByZipQuery(null, null, null);
            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Zipcode)
                               .WithErrorMessage("'Zipcode' must not be empty.")
                               .WithSeverity(Severity.Error)
                               .WithErrorCode("NotEmptyValidator");
        }
    }
}
