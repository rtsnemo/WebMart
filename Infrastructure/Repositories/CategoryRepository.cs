using Application.Abstractions.Categories;
using Application.Abstractions.Products;
using Application.DTO.Products;
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
    public class CategoryRepository(ApplicationDbContext _context) : ICategoryRepository
    {
        private readonly ApplicationDbContext context = _context;
        public async Task<ICollection<Category>> GetAll()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int categoryID)
        {
            return await context.Categories.FirstOrDefaultAsync(q => q.CategoryID == categoryID);
        }

        public async Task AddCategory(Category category)
        {
            _context.Categories.Add(category);
            await context.SaveChangesAsync();
        }

        public async Task UpdateCategory(Category category)
        {
            var existingCategory = await context.Categories.FirstOrDefaultAsync(q => q.CategoryID == category.CategoryID);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.UrlImage = category.UrlImage;
                await context.SaveChangesAsync();
            }
            else
            {
                // Handle case when category is not found
                throw new Exception("Category not found.");
            }
        }

        public async Task DeleteCategory(int categoryID)
        {
            var categoryToDelete = await _context.Categories.FirstOrDefaultAsync(q => q.CategoryID == categoryID);
            if (categoryToDelete != null)
            {
                context.Categories.Remove(categoryToDelete);
                await context.SaveChangesAsync();
            }
            else
            {
                // Handle case when category is not found
                throw new Exception("Category not found.");
            }
        }
    }
}
