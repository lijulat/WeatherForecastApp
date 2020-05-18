using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;

namespace WeatherApi.Infrastructure.OpenWeatherMap
{
    public class OpenWeatherMapClientParam
    {
        private Dictionary<string, string> _parameters;

        private readonly OpenWeatherMapConfig _config;

        public OpenWeatherMapClientParam(OpenWeatherMapConfig config)
        {
            _parameters = new Dictionary<string, string>();
            _config = config;
        }

        private void AddToDict(string key, string value)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value)) return;
            
            if (!_parameters.ContainsKey(key))
            {
                _parameters.Add(key, value);
            }
        }

        public void AddFilterByZipParams(string zipcode, string country, string unit)
        {
            AddToDict("zip", $"{zipcode},{GetCountryValue(country, _config.DefaultCountryCode)}");
            AddCommonParams(unit);
        }

        public void AddFilterByCityParams(string city, string country, string unit)
        {
            AddToDict("q", $"{city},{GetCountryValue(country, _config.DefaultCountryCode)}");
            AddCommonParams(unit);
        }

        private void AddCommonParams(string unit)
        {
            AddToDict("units", unit);
            AddToDict("appid", _config.ApiKey);
        }

        private string GetCountryValue(string country, string defaultValue) => string.IsNullOrEmpty(country) ? defaultValue : country;

        public string ToQueryString() => string.Join("&", _parameters
                                    .Select(param => $"{UrlEncoder.Default.Encode(param.Key)}={UrlEncoder.Default.Encode(param.Value)}"));

    }
}
