using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.GetWeatherForecast.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Features.GetWeatherForecast.Queries
{
    public class GetWeatherForecastQueryHandler : IRequestHandler<GetWeatherForecastQuery, IEnumerable<WeatherForecastDto>>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<IEnumerable<WeatherForecastDto>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            var rng = new Random();
            return Task.FromResult( Enumerable.Range(1, 5).Select(index => new WeatherForecastDto
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }));
        }
    }
}