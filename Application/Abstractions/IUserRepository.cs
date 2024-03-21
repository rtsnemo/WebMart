using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetAll();

        Task<User> GetUserById(int userId);

        Task<User> AddUser(User toCreate);

        Task<User> UpdateUser(int userId, string name, string email);

        Task DeleteUser(int userId);
    }
}
