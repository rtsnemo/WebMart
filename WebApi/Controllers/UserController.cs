using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.MediatR.Users.Queries;
using Application.MediatR.Users.CommandHandlers;
using Microsoft.AspNetCore.Authorization;
using Application.DTO.Users;
using Application.MediatR.Users.Commands;
namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUser command)
        {
            var createdUser = await _mediator.Send(command);

            // Возвращаем объект с кодом состояния HTTP 201 и URI для доступа к созданному пользователю
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.UserID }, createdUser);
        }
        [HttpGet]
        public async Task<IActionResult> GetUserById(int id)
        {
            var getUser = new GetUserById { Id = id };
            var user = await _mediator.Send(getUser);

            return Ok(user);
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignInUser([FromBody]SignInUser query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [Authorize]
        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUser request)
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "sid")?.Value;

            if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
            {
                return Unauthorized();
            }

            var user = await _mediator.Send(new UpdateUser { UserId = userId, Image = request.Image, Name = request.Name});
            return Ok(user);
        }
        [Authorize]
        [HttpGet("get-profile")]
        public async Task<IActionResult> GetProfile()
            {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "sid");

            if (userIdClaim == null)
            {
                return Unauthorized("User ID not found in token");
            }

            if (!int.TryParse(userIdClaim.Value, out int userId))
            {
                return BadRequest("Invalid User ID in token");
            }

            var getUser = new GetUserById { Id = userId };
            var user = await _mediator.Send(getUser);

            return Ok(user);
        }

    }
}
