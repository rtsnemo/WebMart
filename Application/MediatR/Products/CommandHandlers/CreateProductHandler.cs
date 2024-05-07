using Application.Abstractions.Categories;
using Application.Abstractions.Products;
using Application.DTO.Products;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Products.CommandHandlers
{
    public record CreateProductCommand(string Name, string Description, decimal Price, int QuantityInStock, int CategoryId) : IRequest<int>;
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _context;
        private readonly ICategoryRepository _catContext;

        public CreateProductHandler(IProductRepository context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var category = await _catContext.GetCategoryById(command.CategoryId);

            var product = new Product
            {
                Name = command.Name,
                Description = command.Description,
                Price = command.Price,
                QuantityInStock = command.QuantityInStock,
                Category = category
            };

            _context.AddProduct(product);

            return product.ProductID; // Возвращаем ID созданного продукта
        }
    }
}
