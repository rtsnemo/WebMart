using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Abstractions.Users;
using Application.MediatR.Users.CommandHandlers;
using Application.MediatR.Users.Commands;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<ICollection<User>> GetAllUsers()
        {
            return await _context.User.ToListAsync();
        }
        public async Task<User> AddUser(User toCreate)
        {
            _context.User.Add(toCreate);

            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task DeleteUser(int userId)
        {
            var user = _context.User
                .FirstOrDefault(p => p.UserID == userId);

            if (user is null) return;

            _context.User.Remove((User)user);

            await _context.SaveChangesAsync();
        }
        public async Task<User> GetUserById(int personId)
        {
            return await _context.User.FirstOrDefaultAsync(p => p.UserID == personId);
        }

        public async Task<User> GetUserByName(string Name)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Name == Name);

            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Email == email);

            return user;
        }

        public async Task<User> UpdateUserAsync(UpdateUser request)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.UserID == request.UserId);
            if (user == null) throw new KeyNotFoundException("User not found");

            if (!string.IsNullOrEmpty(request.Name))
            {
                user.Name = request.Name;
            }

            if (!string.IsNullOrEmpty(request.Image))
            {
                user.UrlImage = request.Image;
            }

            await _context.SaveChangesAsync();
            return user;
        }
    }
}
