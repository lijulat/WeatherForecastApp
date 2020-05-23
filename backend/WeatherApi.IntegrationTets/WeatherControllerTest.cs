using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApi.Domain.WeatherForecasts;
using WeatherApi.Infrastructure.OpenWeatherMap;
using WeatherApi.Infrastructure.OpenWeatherMap.Dtos;
using WeatherApi.Infrastructure.OpenWeatherMap.Services;
using WeatherApi.IntegrationTests;

namespace WeatherApi.IntegrationTets
{
    [TestClass]
    public class WeatherControllerTest
    {
        private static WebApplicationFactory<WeatherApi.Startup> _factory;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            _factory = new WebApplicationFactory<WeatherApi.Startup>()
                            .WithWebHostBuilder(builder =>
                            {
                                builder.ConfigureServices(
                                    services =>
                                    {
                                        ServiceDescriptor descriptor = services.SingleOrDefault(
                                            d => d.ServiceType ==
                                        typeof(IWeatherForecastClient));

                                        if (descriptor != null)
                                        {
                                            services.Remove(descriptor);
                                        }

                                        services.AddHttpClient<IWeatherForecastClient, MockWeatherClient>();
                                    });
                            });
        }

        [TestMethod]
        public async Task Get_Forecast_By_City_Success()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/weather/forecast/city?cityName=Berlin");
            var responseString = await response.Content.ReadAsStringAsync();
            var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(responseString);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
            Assert.IsNotNull(weatherForecast);
            Assert.AreEqual(TestHelper.MockWeatherForecastResponse.CityData.Name, weatherForecast.City);
            Assert.AreEqual(TestHelper.MockWeatherForecastResponse.CityData.Country, weatherForecast.Country);
        }

        [TestMethod]

        public async Task Get_Forecast_By_City_Bad_Request()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/weather/forecast/city");

            Assert.IsTrue(response.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task Get_Forecast_By_City_Empty_Response()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync($"/api/weather/forecast/city?cityName={TestHelper.InvalidCity}");

            Assert.IsTrue(response.StatusCode == HttpStatusCode.NoContent);
        }

        [TestMethod]
        public async Task Get_Forecast_By_Zip_Success()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/weather/forecast/zip?zipCode=20095");
            var responseString = await response.Content.ReadAsStringAsync();
            var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(responseString);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
            Assert.IsNotNull(weatherForecast);
            Assert.AreEqual(TestHelper.MockWeatherForecastResponse.CityData.Name, weatherForecast.City);
            Assert.AreEqual(TestHelper.MockWeatherForecastResponse.CityData.Country, weatherForecast.Country);
        }

        [TestMethod]

        public async Task Get_Forecast_By_Zip_Bad_Request()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/weather/forecast/zip");

            Assert.IsTrue(response.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task Get_Forecast_By_Zip_Empty_Response()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync($"/api/weather/forecast/zip?zipCode={TestHelper.InvalidZip}");

            Assert.IsTrue(response.StatusCode == HttpStatusCode.NoContent);
        }
    }

    public class MockWeatherClient : IWeatherForecastClient
    {

        private readonly HttpClient _client;

        private readonly OpenWeatherMapConfig _config;

        public MockWeatherClient(HttpClient client, OpenWeatherMapConfig config)
        {
            _client = client;
            _config = config;
        }
        public Task<CurrentWeatherResponse> GetCurrentWeatherByCity(string city, string country, string unit)
        {
            return Task.FromResult(new CurrentWeatherResponse());
        }

        public Task<CurrentWeatherResponse> GetCurrentWeatherByZipcode(string zipcode, string country, string unit)
        {
            return Task.FromResult(new CurrentWeatherResponse());
        }

        public Task<WeatherForecastResponse> GetForecastByCity(string city, string country, string unit)
        {
            if(city == TestHelper.InvalidCity)
            {
                return Task.FromResult<WeatherForecastResponse>(null);
            }
            return Task.FromResult(TestHelper.MockWeatherForecastResponse);
        }

        public Task<WeatherForecastResponse> GetForecastByZipcode(string zipcode, string country, string unit)
        {
            if (zipcode == TestHelper.InvalidZip)
            {
                return Task.FromResult<WeatherForecastResponse>(null);
            }
            return Task.FromResult(TestHelper.MockWeatherForecastResponse);
        }

    }
}
