using Application.Abstractions.Orders;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Order>> GetAll()
        {
            return await _context.Orders.Include(u => u.OrderItems).Include(c => c.Customer).ToListAsync();
        }

        public async Task<ICollection<Order>> GetOrdersByUser(int userId)
        {
            var user =await _context.User.FirstOrDefaultAsync(u => u.UserID == userId);
            return await _context.Orders.Where(u => u.Customer.Email == user.Email).Include(i => i.OrderItems).ThenInclude(p => p.Product).ToListAsync();
        }
    }
}
