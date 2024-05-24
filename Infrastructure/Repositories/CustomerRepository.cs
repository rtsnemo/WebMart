using Application.Abstractions.Categories;
using Application.Abstractions.Customers;
using Application.DTO.Customers;
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
    public class CustomerRepository(ApplicationDbContext _context) : ICustomerRepository
    {
        private readonly ApplicationDbContext context = _context;

        public async Task<Customer> AddCustomer(Customer toCreate)
        {
            _context.Customers.Add(toCreate);

            await _context.SaveChangesAsync();

            return toCreate;
        }

        public Task DeleteCustomer(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerById(int customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(p => p.Email == email);
        }

        public Task<Customer> UpdateCustomer(int customerID, CustomerDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
