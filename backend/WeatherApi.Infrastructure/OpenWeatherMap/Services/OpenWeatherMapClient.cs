using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApi.Infrastructure.OpenWeatherMap;
using WeatherApi.Infrastructure.OpenWeatherMap.Dtos;

namespace WeatherApi.Infrastructure.OpenWeatherMap.Services
{
    public class OpenWeatherMapClient: IWeatherForecastClient
    {

        private readonly HttpClient _client;

        private readonly OpenWeatherMapConfig _config;

        public OpenWeatherMapClient(HttpClient client, OpenWeatherMapConfig config)
        {
            _client = client;
            _config = config;
    }

        public async Task<WeatherForecastResponse> GetForecastByZipcode(string zipcode, string country, string unit)
        {
            var parameter = new OpenWeatherMapClientParam(_config);
            parameter.AddFilterByZipParams(zipcode, country, unit);            

            return await GetApiResponse<WeatherForecastResponse>(parameter, _config.ForecastRoute);
        }

        public async Task<WeatherForecastResponse> GetForecastByCity(string city, string country, string unit)
        {
            var parameter = new OpenWeatherMapClientParam(_config);
            parameter.AddFilterByCityParams(city, country, unit);

            return await GetApiResponse<WeatherForecastResponse>(parameter, _config.ForecastRoute);
        }

        public async Task<CurrentWeatherResponse> GetCurrentWeatherByCity(string city, string country, string unit)
        {
            var parameter = new OpenWeatherMapClientParam(_config);
            parameter.AddFilterByCityParams(city, country, unit);

            return await GetApiResponse<CurrentWeatherResponse>(parameter, _config.CurrentWeatherRoute);
        }

        public async Task<CurrentWeatherResponse> GetCurrentWeatherByZipcode(string zipcode, string country, string unit)
        {
            var parameter = new OpenWeatherMapClientParam(_config);
            parameter.AddFilterByZipParams(zipcode, country, unit);

            return await GetApiResponse<CurrentWeatherResponse>(parameter, _config.CurrentWeatherRoute);
        }

        private async Task<T> GetApiResponse<T>(OpenWeatherMapClientParam parameter, string path) where T: class
        {
            var queryParams = parameter.ToQueryString();

            var uriBuilder = new UriBuilder(_config.ApiBaseUrl) { Path = path, Query = queryParams };           

            using var httpResponse = await _client.GetAsync(uriBuilder.ToString(), HttpCompletionOption.ResponseHeadersRead);

            if (httpResponse.IsSuccessStatusCode)
            {
                var contentStream = await httpResponse.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<T>(contentStream);               
            }

            return null;           
        }
        
    }
}
