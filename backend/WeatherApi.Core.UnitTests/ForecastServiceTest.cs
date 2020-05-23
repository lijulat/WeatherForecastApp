using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApi.Core.WeatherForecasts.Mappers;
using WeatherApi.Core.WeatherForecasts.Services;
using WeatherApi.Domain.WeatherForecasts;
using WeatherApi.Infrastructure.OpenWeatherMap;
using WeatherApi.Infrastructure.OpenWeatherMap.Dtos;
using WeatherApi.Infrastructure.OpenWeatherMap.Services;

namespace WeatherApi.Core.UnitTests
{
    [TestClass]
    public class ForecastServiceTest
    {
        private IForecastService _forecastService;
        private readonly OpenWeatherMapConfig _openWeatherMapConfig;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IMapper _mapper;
        private readonly CurrentWeatherResponse _mockCurrentWeatherResponse;
        private readonly WeatherForecastResponse _mockWeatherForecastResponse;
        private Mock<Func<string, string, string, Task<WeatherForecastResponse>>> _mockGetForecastFunc;
        private Mock<Func<string, string, string, Task<CurrentWeatherResponse>>> _mockGetCurrentWeatherFunc;

        public ForecastServiceTest()
        {
            _openWeatherMapConfig = new OpenWeatherMapConfig { IconUrl = "fakeurl/{0}.png" };
            _mockMapper = new Mock<IMapper>();
            _mockGetForecastFunc = new Mock<Func<string, string, string, Task<WeatherForecastResponse>>>();
            _mockGetCurrentWeatherFunc = new Mock<Func<string, string, string, Task<CurrentWeatherResponse>>>();
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new WeatherForecastMappingProfile());
            }).CreateMapper();

            _mockCurrentWeatherResponse = new CurrentWeatherResponse()
            {
                DateUnixFormat = 1590144273,
                WeatherInfo = new WeatherCondition { Temperature = 69.55, Humidity = 50 },
                WindData = new Wind { Speed = 9.53 },
                WeatherData = new WeatherResponse[] { new WeatherResponse { Icon = "04d" } }
            };

            _mockWeatherForecastResponse = new WeatherForecastResponse()
            {
                CityData = new City { Name = "Hamburg", Country = "DE" },
                ForecastData = new ForecastResponse[] {
                                                new ForecastResponse {
                                                                        DateUnixFormat = 1590559200,
                                                                        WeatherInfo = new WeatherCondition {
                                                                        Temperature = 69.55,
                                                                        Humidity = 50
                                                                      },
                    WindData = new Wind() { Speed = 9.53 },
                    WeatherData = new WeatherResponse[] { new WeatherResponse { Icon = "04d" } }} }
            };
        }


        [TestInitialize]
        public void TestInitialize()
        {
            _mockMapper.Setup(x => x.Map<WeatherForecastResponse, WeatherForecast>(It.IsAny<WeatherForecastResponse>())).Returns(It.IsAny<WeatherForecast>());
            _mockMapper.Setup(x => x.Map<CurrentWeatherResponse, ForecastDetails>(It.IsAny<CurrentWeatherResponse>())).Returns(It.IsAny<ForecastDetails>());
        }

        [TestMethod]
        public void Get_Forecast_Verify_Forecast_Func_Call()
        {
            _forecastService = new ForecastService(_openWeatherMapConfig, _mockMapper.Object);

            _mockGetForecastFunc.Setup(x => x.Invoke(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(It.IsAny<WeatherForecastResponse>()));

            var response = _forecastService.GetForecast(_mockGetForecastFunc.Object,
                                                        It.IsAny<Func<string, string, string, Task<CurrentWeatherResponse>>>(),
                                                        It.IsAny<string>(),
                                                        It.IsAny<string>(),
                                                        It.IsAny<string>());

            _mockGetForecastFunc.Verify(x => x.Invoke(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            Assert.IsNull(response.Result);
        }

        [TestMethod]
        public void Get_Forecast_Verify_Forecast_Mapper_Call()
        {
            _forecastService = new ForecastService(_openWeatherMapConfig, _mockMapper.Object);

            _mockGetForecastFunc.Setup(x => x.Invoke(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(_mockWeatherForecastResponse));


            var response = _forecastService.GetForecast(_mockGetForecastFunc.Object,
                                                        It.IsAny<Func<string, string, string, Task<CurrentWeatherResponse>>>(),
                                                        It.IsAny<string>(),
                                                        It.IsAny<string>(),
                                                        It.IsAny<string>());

            _mockMapper.Verify(x => x.Map<WeatherForecast>(It.IsAny<WeatherForecastResponse>()), Times.Once);
            _mockGetForecastFunc.Verify(x => x.Invoke(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            Assert.IsNull(response.Result);
        }

        [TestMethod]
        public void Get_Forecast_Verify_Current_Weather_Func_Call()
        {

            _mockMapper.Setup(x => x.Map<WeatherForecast>(_mockWeatherForecastResponse)).Returns(new WeatherForecast
            {
                DailyForecasts = new List<ForecastDetails>()
            });

            _forecastService = new ForecastService(_openWeatherMapConfig, _mockMapper.Object);

            _mockGetForecastFunc.Setup(x => x.Invoke(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(_mockWeatherForecastResponse));

            _mockGetCurrentWeatherFunc.Setup(x => x.Invoke(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(It.IsAny<CurrentWeatherResponse>()));

            _forecastService.GetForecast(_mockGetForecastFunc.Object,
                                                        _mockGetCurrentWeatherFunc.Object,
                                                        It.IsAny<string>(),
                                                        It.IsAny<string>(),
                                                        It.IsAny<string>());

            _mockGetForecastFunc.Verify(x => x.Invoke(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            _mockGetCurrentWeatherFunc.Verify(x => x.Invoke(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void Get_Forecast_Verify_Current_Weather_Mapper_Call()
        {
            _mockMapper.Setup(x => x.Map<WeatherForecast>(_mockWeatherForecastResponse)).Returns(new WeatherForecast
            {
                DailyForecasts = new List<ForecastDetails>()
            });

            _forecastService = new ForecastService(_openWeatherMapConfig, _mockMapper.Object);

            _mockGetForecastFunc.Setup(x => x.Invoke(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(_mockWeatherForecastResponse));

            _mockGetCurrentWeatherFunc.Setup(x => x.Invoke(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(_mockCurrentWeatherResponse));

            var response = _forecastService.GetForecast(_mockGetForecastFunc.Object,
                                                        _mockGetCurrentWeatherFunc.Object,
                                                        It.IsAny<string>(),
                                                        It.IsAny<string>(),
                                                        It.IsAny<string>());


            _mockGetForecastFunc.Verify(x => x.Invoke(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            _mockGetCurrentWeatherFunc.Verify(x => x.Invoke(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);

            _mockMapper.Verify(x => x.Map<WeatherForecast>(It.IsAny<WeatherForecastResponse>()), Times.Once);
            _mockMapper.Verify(x => x.Map<ForecastDetails>(It.IsAny<CurrentWeatherResponse>()), Times.Once);
            Assert.IsNull(response.Result);
        }

        [TestMethod]
        public void Get_Forecast_Verify_Response()
        {

            _forecastService = new ForecastService(_openWeatherMapConfig, _mapper);

            _mockGetForecastFunc.Setup(x => x.Invoke(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(_mockWeatherForecastResponse));

            _mockGetCurrentWeatherFunc.Setup(x => x.Invoke(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(_mockCurrentWeatherResponse));

            var response = _forecastService.GetForecast(_mockGetForecastFunc.Object,
                                                        _mockGetCurrentWeatherFunc.Object,
                                                        It.IsAny<string>(),
                                                        It.IsAny<string>(),
                                                        It.IsAny<string>());

            Assert.IsInstanceOfType(response.Result, typeof(WeatherForecast));
            Assert.AreEqual(_mockWeatherForecastResponse.CityData.Name, response.Result.City);
            Assert.AreEqual(_mockWeatherForecastResponse.CityData.Country, response.Result.Country);
            Assert.IsTrue(response.Result.DailyForecasts.Count > 0);
        }


    }
}
