using System;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Application.Features.GetProducts.Queries;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] GetProductsQuery query)
        {
            IEnumerable<GetProductsQuery.Product> products = await mediator.Send(query);

            return products.Any() ? Ok(products) : NotFound(query);
        }
    }
}
