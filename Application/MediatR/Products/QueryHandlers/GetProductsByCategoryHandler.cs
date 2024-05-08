using Application.Abstractions.Products;
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
    public class GetProductsByCategoryHandler(IProductRepository productRepository) : IRequestHandler <GetProductsByCategory, ICollection<Product>>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<ICollection<Product>> Handle(GetProductsByCategory request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductsByCategory(request.categoryID);
        }
    }
}
