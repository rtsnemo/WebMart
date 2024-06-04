using Application.Abstractions.Products;
using Application.MediatR.Products.CommandHandlers;
using Application.MediatR.Products.Commands;
using Application.MediatR.Products.Queries;
using Application.MediatR.Products.QueryHandlers;
using Application.MediatR.Users.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IMediator mediator, IProductRepository productRepository) : ControllerBase
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMediator _mediator = mediator;

        [HttpPost("create-product")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var productId = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateProduct), new { id = productId }, productId);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _mediator.Send(new GetAllProducts());
            return Ok(products);
        }

        [HttpGet("category/{categoryID}")]
        public async Task<IActionResult> GetProductsByCategory(int categoryID)
        {
            var products = await _mediator.Send(new GetProductsByCategory { categoryID = categoryID });
            return Ok(products);
        }

        [HttpGet("products/{productID}")]
        public async Task<IActionResult> GetProductById(int productID)
        {
            var getProduct = new GetProductById { Id = productID };
            var product = await _mediator.Send(getProduct);

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(UpdateProduct product)
        {
            try
            {
                var updatedProduct = await _mediator.Send(product);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
