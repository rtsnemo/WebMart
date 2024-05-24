using Application.Abstractions.Customers;
using Application.Abstractions.Users;
using Application.DTO.Orders;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICustomerRepository _customerRepository;

        public OrdersController(ApplicationDbContext context, ICustomerRepository customerRepository)
        {
            _context = context;
            _customerRepository = customerRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            // Создание пользователя, если его нет
            var existingCustomer = await _customerRepository.GetCustomerByEmail(request.Customer.Email);
            if (existingCustomer == null)
                existingCustomer = new Customer
                {
                    Address = request.Customer.Address,
                    Email = request.Customer.Email,
                    Name = request.Customer.Name,
                    PhoneNumber = request.Customer.PhoneNumber,
                };

                await _customerRepository.AddCustomer(existingCustomer);

            // Создание заказа
            var order = new Order
            {
                OrderDate = DateTime.UtcNow,
                Status = "Pending",
                CustomerID = existingCustomer.CustomerID,
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync(); // Сохранить, чтобы получить OrderID

            // Создание элементов заказа
            var orderItems = new List<OrderItem>();
            foreach (var item in request.OrderItems)
            {
                // Проверка, существует ли продукт
                var product = await _context.Products.FindAsync(item.ProductID);
                if (product == null)
                {
                    return NotFound($"Product with ID {item.ProductID} not found.");
                }

                var orderItem = new OrderItem
                {
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                    Price = item.Price
                };
                orderItems.Add(orderItem);
            }

            _context.OrderItems.AddRange(orderItems);
            await _context.SaveChangesAsync();

            // Возвращение ответа с созданным заказом и элементами заказа
            var response = new
            {
                order.OrderID,
                order.OrderDate,
                order.Status,
                order.CustomerID,
                OrderItems = orderItems.Select(oi => new
                {
                    oi.OrderItemID,
                    oi.ProductID,
                    oi.Quantity,
                    oi.Price
                }).ToList()
            };

            return Ok(response);
        }
    }
}