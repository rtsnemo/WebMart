using Application.Abstractions;
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
        private readonly PasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository, PasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
        }

        public async Task<User> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var username = request.Name;
            var email = request.Email;
            var password = _passwordHasher.HashPassword(request.Password);

            // Проверяем, существует ли пользователь с таким именем

            // Создаем нового пользователя
            var newUser = new User
            {
                Name = username,
                Email = email,
                Password = password.Hash, // В реальном приложении следует хешировать пароль
                Salt = password.Salt
            };

            // Добавляем пользователя в базу данных
            _userRepository.AddUser(newUser);
        }
    }
}
