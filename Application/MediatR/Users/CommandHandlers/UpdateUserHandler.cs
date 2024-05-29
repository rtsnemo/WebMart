using Application.Abstractions.Users;
using Application.MediatR.Users.Commands;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Users.CommandHandlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUser, User>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            // Проверяем, существует ли пользователь
            var existingUser = await _userRepository.GetUserById(request.UserId);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {request.UserId} not found.");
            }

            await _userRepository.UpdateUserAsync(request);

            return existingUser;
        }
    }
}
