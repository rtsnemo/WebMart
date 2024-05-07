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
    }
}
