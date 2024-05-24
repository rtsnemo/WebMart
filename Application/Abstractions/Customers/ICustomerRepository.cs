using Application.DTO.Customers;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Customers
{
    public interface ICustomerRepository
    {
        Task<ICollection<Customer>> GetAll();

        Task<Customer> GetCustomerById(int customerId);

        Task<Customer> GetCustomerByEmail(string email);

        Task<Customer> AddCustomer(Customer toCreate);

        Task<Customer> UpdateCustomer(int customerID, CustomerDTO request);

        Task DeleteCustomer(int userId);
    }
}
