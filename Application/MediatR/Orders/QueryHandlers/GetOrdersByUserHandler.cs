using Application.Abstractions.Orders;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Orders.QueryHandlers
{
    public record GetOrdersByUser(int userId) : IRequest<ICollection<Order>>;
    public class GetOrdersByUserHandler(IOrderRepository orderRepository) : IRequestHandler<GetOrdersByUser, ICollection<Order>>
    {
        private readonly IOrderRepository _orderRepository = orderRepository;
        public async Task<ICollection<Order>> Handle(GetOrdersByUser request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrdersByUser(request.userId);
        }
    }
}
