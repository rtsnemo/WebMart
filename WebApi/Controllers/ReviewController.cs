using Application.MediatR.Products.CommandHandlers;
using Application.MediatR.Reviews.CommandHandlers;
using Application.MediatR.Reviews.Commands;
using Application.MediatR.Reviews.QueryHandlers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> CreateReview([FromBody] CreateReview command)
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "sid")?.Value;

            if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
            {
                return Unauthorized();
            }

            var newReview = new CreateReview { Comment = command.Comment, UserId = userId, ProductId = command.ProductId };
            var reviewId = await _mediator.Send(newReview);
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
