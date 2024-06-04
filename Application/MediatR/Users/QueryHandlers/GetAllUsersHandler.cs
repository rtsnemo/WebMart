using Application.Abstractions.Categories;
using Application.Abstractions.Products;
using Application.Abstractions.Users;
using Application.MediatR.Products.QueryHandlers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Users.QueryHandlers
{
    public record GetAllUsers() : IRequest<ICollection<User>>;
    public class GetAllOrdersHandler(IUserRepository userRepository) : IRequestHandler<GetAllUsers,ICollection<User>>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<ICollection<User>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllUsers();
        }
    }
}
