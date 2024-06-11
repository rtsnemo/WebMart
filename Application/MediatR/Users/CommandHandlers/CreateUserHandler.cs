using Application.Abstractions.Users;
using Domain.Entities;
using MediatR;

namespace Application.MediatR.Users.CommandHandlers
{
    public record CreateUser(string Name, string Email, string Password) : IRequest<User>;

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
                UrlImage = null,
                Balance = 0,
                Role = 0,
                Email = email,
                Password = Hash,
                Salt = Salt
            };

            await _userRepository.AddUser(newUser);

            return newUser;
        }
    }
}
