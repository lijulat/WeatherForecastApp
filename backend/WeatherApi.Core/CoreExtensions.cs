using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using WeatherApi.Core.Behaviours;
using WeatherApi.Core.WeatherForecasts.Services;
using FluentValidation;
using WeatherApi.Infrastructure;
using AutoMapper;

namespace WeatherApi.Core
{
    public static class CoreExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IForecastService, ForecastService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
