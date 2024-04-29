using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.MediatR.Users.Queries;
using Domain.Entities;
using Microsoft.VisualBasic;
using Application.MediatR.Users.Commands;
using Application.MediatR.Users.QueryHandlers;
namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
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
