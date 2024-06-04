using Application.Abstractions.Products;
using Application.Abstractions.Users;
using Application.MediatR.Products.Commands;
using Application.MediatR.Users.Commands;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Products.CommandHandlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProduct, Product>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(UpdateProduct request, CancellationToken cancellationToken)
        {
            // Проверяем, существует ли пользователь
            var existingProduct = await _productRepository.GetProductById(request.ProductID);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"User with ID {request.ProductID} not found.");
            }

            await _productRepository.UpdateProduct(request);

            return existingProduct;
        }
    }
}
