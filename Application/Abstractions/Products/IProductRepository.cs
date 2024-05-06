using Application.DTO.Products;
using Application.MediatR.Products.Queries;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Products
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetAll();

        Task<Product> GetProductById(int productId);

        Task<Product> GetProductByName(string name);

        Task<Product> AddProduct(Product toCreate);

        Task<Product> UpdateProduct(int productId, ProductDTO update);

        Task<ICollection<Product>> GetProductsByCategory(int categoryID);

        Task DeleteProduct(int productId);
    }
}
