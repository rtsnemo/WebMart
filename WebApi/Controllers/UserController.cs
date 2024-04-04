using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.MediatR.Users.Queries;
using Domain.Entities;
using Microsoft.VisualBasic;
using Application.MediatR.Users.Commands;
namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CreateUser(IMediator mediator, [FromBody] CreateUser command)
        {
            var createdUser = await mediator.Send(command);

            // Возвращаем объект с кодом состояния HTTP 201 и URI для доступа к созданному пользователю
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.UserID }, createdUser);
        }
        [HttpGet]
        public async Task<IResult> GetUserById(IMediator mediator, int id)
        {
            var getUser = new GetUserById { Id = id };
            var user = await mediator.Send(getUser);

            return TypedResults.Ok(user);
        }
    }
}
