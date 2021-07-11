using MediatR;
using Application.Features.GetWeatherForecast.Dtos;
using System.Collections.Generic;

namespace Application.Features.GetWeatherForecast.Queries
{
    public class GetWeatherForecastQuery : IRequest<IEnumerable<WeatherForecastDto>>
    {
        
    }
}