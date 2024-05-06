using Application.Abstractions.Users;
using Application.MediatR.Users.Commands;
using Domain.Entities;
using Infrastructure.Services.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Users.CommandHandlers
{
    public class CreateUserHandler : IRequestHandler<CreateUser, User>
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
        }

        public async Task<User> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var username = request.Name;
            var email = request.Email;
            var (Hash, Salt) = _passwordHasher.HashPassword(request.Password);

            var newUser = new User
            {
                Name = username,
                Balance = request.Balance,
                Role = request.Role,
                Email = email,
                Password = Hash,
                Salt = Salt
            };

            await _userRepository.AddUser(newUser);

            return newUser;
        }
    }
}
