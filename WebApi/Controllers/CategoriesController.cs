using Application.Abstractions.Categories;
using Application.MediatR.Categories.QueryHandlers;
using Application.MediatR.Products.QueryHandlers;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(IMediator mediator, ICategoryRepository categoryRepository)
        {
            _mediator = mediator;
            _categoryRepository = categoryRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _mediator.Send(new GetAllCategories());
            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            await _categoryRepository.AddCategory(category);
            return CreatedAtAction("GetCategory", new { id = category.CategoryID }, category);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.CategoryID)
            {
                return BadRequest();
            }

            try
            {
                await _categoryRepository.UpdateCategory(category);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            try
            {
                await _categoryRepository.DeleteCategory(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
