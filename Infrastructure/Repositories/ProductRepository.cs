using Application.Abstractions.Products;
using Application.DTO.Products;
using Application.MediatR.Products.Queries;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository(ApplicationDbContext _context) : IProductRepository
    {
        public async Task<Product> AddProduct(Product toCreate)
        {
            _context.Products.Add(toCreate);

            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task DeleteProduct(int productId)
        {
            var product = _context.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product is null) return;

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductID == productId);
        }

        public async Task<Product> GetProductByName(string name)
        {
            var user = await _context.Products.FirstOrDefaultAsync(x => x.Name == name);

            return user;
        }

        public async Task<Product> UpdateProduct(int productId, ProductDTO update)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductID == productId);

            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {productId} not found.");
            }

            var updateProperties = typeof(ProductDTO).GetProperties();

            foreach (var prop in updateProperties)
            {
                var newValue = prop.GetValue(update);

                // Если значение не null, применяем к объекту продукта
                if (newValue != null)
                {
                    var productProperty = typeof(Product).GetProperty(prop.Name);

                    if (productProperty != null)
                    {
                        productProperty.SetValue(product, newValue);
                    }
                }
            }

            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<ICollection<Product>> GetProductsByCategory(int categoryID)
        {
            return await _context.Products.Where(x => x.Category.CategoryID == categoryID).ToListAsync();
        }
    }
}
