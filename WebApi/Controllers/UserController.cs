using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.MediatR.Users.Queries;
using Application.MediatR.Users.CommandHandlers;
namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
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
    }
}
