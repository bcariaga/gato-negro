using System;
using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Application.Features.GetWeatherForecast.Queries;
using Application.Features.GetWeatherForecast.Dtos;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> logger;
        private readonly IMediator mediator;

        public WeatherForecastController(IMediator mediator, ILogger<WeatherForecastController> logger)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecastDto>> Get() => 
            await this.mediator.Send(new GetWeatherForecastQuery());
    }
}
