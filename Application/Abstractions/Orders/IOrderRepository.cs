using Application.DTO.Products;
using Application.MediatR.Products.Queries;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Orders
{
    public interface IOrderRepository
    {
        Task<ICollection<Order>> GetAll();

    }
}
