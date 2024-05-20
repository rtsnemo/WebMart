using Application.Abstractions.Products;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Products.QueryHandlers
{
    public record GetAllProducts() : IRequest<ICollection<Product>>;

    public class GetAllProductsHandler : IRequestHandler<GetAllProducts, ICollection<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ICollection<Product>> Handle(GetAllProducts request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAll();
        }
    }
}
