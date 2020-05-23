using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WeatherApi.Infrastructure.OpenWeatherMap;
using WeatherApi.Infrastructure.OpenWeatherMap.Dtos;
using WeatherApi.Infrastructure.OpenWeatherMap.Services;

namespace WeatherApi.Infrastructure.UnitTests
{
    [TestClass]
    public class OpenWeatherMapClientTest
    {
        private Mock<HttpClient> _mockHttpClient;
        private readonly OpenWeatherMapConfig _mockConfig;
        private IWeatherForecastClient _client;
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;

        public OpenWeatherMapClientTest()
        {
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            _mockConfig = new OpenWeatherMapConfig() { ApiBaseUrl = "fakebaseurl" };
        }

        [TestMethod]
        public void Get_Current_Weather_Success()
        {
            var payload = new
            {
                cod = 200,
                coord = new { lon = 9.89, lat = 53.47 }
            };

            //Arrange
            _mockHttpMessageHandler.Protected().
                Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                 .ReturnsAsync(new HttpResponseMessage
                 {
                     StatusCode = HttpStatusCode.OK,
                     Content = new StringContent(JsonSerializer.Serialize(payload))
                 });

            _mockHttpClient = new Mock<HttpClient>(_mockHttpMessageHandler.Object);

            _client = new OpenWeatherMapClient(_mockHttpClient.Object, _mockConfig);

            var response = _client.GetCurrentWeatherByCity(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsInstanceOfType(response.Result, typeof(CurrentWeatherResponse));
            Assert.AreEqual(payload.cod, response.Result.Code);
            Assert.AreEqual(payload.coord.lat, response.Result.Coordinates.Lat);
            Assert.AreEqual(payload.coord.lon, response.Result.Coordinates.Lon);
        }

        [TestMethod]
        public void Get_Current_Weather_Fail()
        {

            //Arrange
            _mockHttpMessageHandler.Protected().
                Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                 .ReturnsAsync(new HttpResponseMessage
                 {
                     StatusCode = HttpStatusCode.BadRequest
                 });

            _mockHttpClient = new Mock<HttpClient>(_mockHttpMessageHandler.Object);

            _client = new OpenWeatherMapClient(_mockHttpClient.Object, _mockConfig);

            var response = _client.GetCurrentWeatherByCity(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.IsNull(response.Result);
        }

        [TestMethod]
        public void Get_Forecast_Weather_Success()
        {
            var payload = new
            {
                cod = "200",
                city = new
                {
                    name = "Hamburg Hausbruch",
                    coord = new
                    {
                        lat = 53.4703,
                        lon = 9.8933
                    },
                    country = "DE",
                    timezone = 7200,
                    sunrise = 1590116956,
                    sunset = 1590175516
                }
            };

            //Arrange
            _mockHttpMessageHandler.Protected().
                Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                 .ReturnsAsync(new HttpResponseMessage
                 {
                     StatusCode = HttpStatusCode.OK,
                     Content = new StringContent(JsonSerializer.Serialize(payload))
                 });

            _mockHttpClient = new Mock<HttpClient>(_mockHttpMessageHandler.Object);

            _client = new OpenWeatherMapClient(_mockHttpClient.Object, _mockConfig);

            var response = _client.GetForecastByZipcode(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsInstanceOfType(response.Result, typeof(WeatherForecastResponse));

            Assert.AreEqual(payload.cod, response.Result.Code);
            Assert.AreEqual(payload.city.name, response.Result.CityData.Name);
            Assert.AreEqual(payload.city.coord.lon, response.Result.CityData.Coordinates.Lon);
            Assert.AreEqual(payload.city.coord.lat, response.Result.CityData.Coordinates.Lat);
            Assert.AreEqual(payload.city.country, response.Result.CityData.Country);
            Assert.AreEqual(payload.city.timezone, response.Result.CityData.Timezone);
            Assert.AreEqual(payload.city.sunrise, response.Result.CityData.Sunrise);
            Assert.AreEqual(payload.city.sunset, response.Result.CityData.Sunset);
        }

        [TestMethod]
        public void Get_Forecast_Weather_Fail()
        {

            //Arrange
            _mockHttpMessageHandler.Protected().
                Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                 .ReturnsAsync(new HttpResponseMessage
                 {
                     StatusCode = HttpStatusCode.BadRequest
                 });

            _mockHttpClient = new Mock<HttpClient>(_mockHttpMessageHandler.Object);

            _client = new OpenWeatherMapClient(_mockHttpClient.Object, _mockConfig);

            var response = _client.GetForecastByZipcode(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.IsNull(response.Result);
        }

    }
}
