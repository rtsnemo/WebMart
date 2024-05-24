using Application.DTO.Customers;
using Application.DTO.OrderItems;
using Application.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Orders
{
    public class CreateOrderRequest
    {
        public CustomerDTO Customer { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }
    }
}
