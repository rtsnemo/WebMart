using Application.Abstractions.Categories;
using Application.Abstractions.Products;
using Application.MediatR.Products.QueryHandlers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Categories.QueryHandlers
{
    public record GetAllCategories() : IRequest<ICollection<Category>>;
    public class GetAllCategoriesHandler
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoriesHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<ICollection<Category>> Handle(GetAllCategories request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetAll();
        }
    }
}
