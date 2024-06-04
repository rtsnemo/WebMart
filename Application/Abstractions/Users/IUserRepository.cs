using Application.MediatR.Users.CommandHandlers;
using Application.MediatR.Users.Commands;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Users
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetAllUsers();

        Task<User> GetUserById(int userId);

        Task<User> GetUserByName(string name);

        Task<User> GetUserByEmail(string email);

        Task<User> AddUser(User toCreate);

        Task<User> UpdateUserAsync(UpdateUser update);

        Task DeleteUser(int userId);
    }
}
