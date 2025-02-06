using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrdersSonae.Business.Commands;
using OrdersSonae.Business.DTOs;
using OrdersSonae.Business.Queries;

namespace OrdersSonae.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("initialize")]
        public async Task<ActionResult> InitializeProducts()
        {
            try
            {
                var products = new List<CreateProductCommand>
                {
                    new CreateProductCommand("Laptop", 999.99m),
                    new CreateProductCommand("Smartphone", 599.99m),
                    new CreateProductCommand("Headphones", 149.99m),
                    new CreateProductCommand("Tablet", 399.99m),
                    new CreateProductCommand("Smartwatch", 299.99m)
                };

                foreach (var product in products)
                {
                    await _mediator.Send(product);
                }

                return Ok("5 products initialized successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(Guid id)
        {
            try
            {
                var query = new GetProductQuery(id);
                var product = await _mediator.Send(query);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            try
            {
                var query = new GetAllProductsQuery();
                var products = await _mediator.Send(query);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
