using Application.Abstractions.Users;
using Application.MediatR.Users.Queries;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Users.QueryHandlers
{
    public class GetUserByIdHandler
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserById(request.Id);
        }
    }
}
