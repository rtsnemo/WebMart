using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Categories
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetAll();
        Task<Category> GetCategoryById(int categoryID);
    }
}
