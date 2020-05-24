using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Polly;
using System;
using System.Net.Http;
using WeatherApi.Infrastructure.OpenWeatherMap;
using WeatherApi.Infrastructure.OpenWeatherMap.Services;

namespace WeatherApi.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<OpenWeatherMapConfig>(configuration.GetSection("OpenWeatherMapApi"));

            // Explicitly register the settings object by delegating to the IOptions object
            services.AddSingleton(resolver =>
                resolver.GetRequiredService<IOptions<OpenWeatherMapConfig>>().Value);

            var openWeatherMapConfig = configuration.GetSection("OpenWeatherMapApi").Get<OpenWeatherMapConfig>();

            services.AddHttpClient<IWeatherForecastClient, OpenWeatherMapClient>()
                .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(openWeatherMapConfig.TimoutSeconds)))
                .AddTransientHttpErrorPolicy(p => p.RetryAsync(openWeatherMapConfig.RetryCount));

            return services;
        }
    }
}
