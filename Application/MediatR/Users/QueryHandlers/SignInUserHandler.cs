using Application.Abstractions.Users;
using Application.MediatR.Users.Queries;
using Domain.Entities;
using Infrastructure.Services.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Users.QueryHandlers
{
    public class SignInUserHandler : IRequestHandler<SignInUser, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJWTGeneratorService _jwtGeneratorService;

        public SignInUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJWTGeneratorService jwtGeneratorService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtGeneratorService = jwtGeneratorService;
        }

        public async Task<string> Handle(SignInUser request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(request.Email) ??
                throw new InvalidDataException("No user with this name.");
            if (!_passwordHasher.VerifyPassword(request.Password, user.Password, user.Salt))
            {
                throw new InvalidDataException("Wrong password!");
            }

            return _jwtGeneratorService.GenerateJwtToken(user);
        }

    }
}
