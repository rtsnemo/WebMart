using Application.Abstractions.Categories;
using Application.Abstractions.Orders;
using Application.Abstractions.Products;
using Application.MediatR.Products.QueryHandlers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Orders.QueryHandlers
{
    public record GetAllOrders() : IRequest<ICollection<Order>>;
    public class GetAllOrdersHandler(IOrderRepository orderRepository) : IRequestHandler<GetAllOrders,ICollection<Order>>
    {
        private readonly IOrderRepository _orderRepository = orderRepository;

        public async Task<ICollection<Order>> Handle(GetAllOrders request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetAll();
        }
    }
}
