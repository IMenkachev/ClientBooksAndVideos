using CustomerQuery.API.Features.Queries.Products.GetProduct;
using CustomerQuery.API.Features.Queries.Products.GetProducts;
using CustomerQuery.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CustomerQuery.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var query = new GetProductsQuery();
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductDto>> GetById(Guid id)
        {
            var query = new GetProductQuery(id);
            var product = await _mediator.Send(query);
            return Ok(product);
        }
    }
}
