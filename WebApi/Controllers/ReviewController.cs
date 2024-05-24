using Application.MediatR.Products.CommandHandlers;
using Application.MediatR.Reviews.CommandHandlers;
using Application.MediatR.Reviews.QueryHandlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewCommand command)
        {
            var reviewId = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateReview), new { id = reviewId }, reviewId);
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetReviewsByProduct(int productId)
        {
            var reviews = await _mediator.Send(new GetReviewsByProduct(productId));

            return Ok(reviews);
        }
    }
}
