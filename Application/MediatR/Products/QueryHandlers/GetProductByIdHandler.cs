using Application.Abstractions.Products;
using Application.Abstractions.Users;
using Application.MediatR.Products.Queries;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Products.QueryHandlers
{
    internal class GetProductByIdHandler(IProductRepository productRepository) : IRequestHandler<GetProductById, Product>
    {
        private readonly IProductRepository _productRepository = productRepository;
        public Task<Product> Handle(GetProductById request, CancellationToken cancellationToken)
        {
            return _productRepository.GetProductById(request.Id);
        }
    }
}
