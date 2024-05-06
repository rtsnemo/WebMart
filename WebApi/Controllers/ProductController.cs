using Application.MediatR.Products.Queries;
using Application.MediatR.Products.QueryHandlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
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
            var products = await _mediator.Send(new GetProductsByCategory(categoryID));
            return Ok(products);
        }
    }
}
