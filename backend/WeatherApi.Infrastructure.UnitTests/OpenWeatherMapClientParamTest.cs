using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WeatherApi.Infrastructure.OpenWeatherMap;

namespace WeatherApi.Infrastructure.UnitTests
{
    [TestClass]
    public class OpenWeatherMapClientParamTest
    {
        private OpenWeatherMapClientParam _openWeatherMapClientParam;
        private readonly OpenWeatherMapConfig _mockConfig;
        private readonly string _fakeCity = "fakecity";
        private readonly string _fakeZip = "fakezip";
        private readonly string _fakeCountry = "fakeCountry";
        private readonly string _fakeUnit = "fakeUnit";

        public OpenWeatherMapClientParamTest()
        {
            _mockConfig = new OpenWeatherMapConfig();
            _openWeatherMapClientParam = new OpenWeatherMapClientParam(_mockConfig);
        }

        [TestMethod]
        public void Add_City_Param_When_Non_Empty()
        {
            // Arrange
            _openWeatherMapClientParam.AddFilterByCityParams(_fakeCity, _fakeCountry, _fakeUnit);
            var expectedResult = $"q={_fakeCity},{_fakeCountry}&units={_fakeUnit}";

            //Act
            var actualResult = _openWeatherMapClientParam.ToQueryString();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Should_Not_Add_Param_When_Existingy()
        {
            // Arrange
            _openWeatherMapClientParam.AddFilterByCityParams(_fakeCity, _fakeCountry, _fakeUnit);
            _openWeatherMapClientParam.AddFilterByCityParams("randomCity", _fakeCountry, _fakeUnit);
            var expectedResult = $"q={_fakeCity},{_fakeCountry}&units={_fakeUnit}";

            // Act
            var actualResult = _openWeatherMapClientParam.ToQueryString();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Add_Zip_Param_When_Non_Empty()
        {
            // Arrange
            _openWeatherMapClientParam.AddFilterByZipParams(_fakeZip, _fakeCountry, _fakeUnit);
            var expectedResult = $"zip={_fakeZip},{_fakeCountry}&units={_fakeUnit}";

            // Act
            var actualResult = _openWeatherMapClientParam.ToQueryString();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Add_Config_Param_Config_Non_Empty()
        {
            // Arrange
            _openWeatherMapClientParam = new OpenWeatherMapClientParam(new OpenWeatherMapConfig() { DefaultCountryCode = "DE", ApiKey = "AppId" });
            _openWeatherMapClientParam.AddFilterByZipParams(_fakeZip, "", _fakeUnit);
            var expectedResult = $"zip={_fakeZip},DE&units={_fakeUnit}&appid=AppId";
            
            // Act
            var actualResult = _openWeatherMapClientParam.ToQueryString();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
