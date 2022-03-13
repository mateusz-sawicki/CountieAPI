using CountieAPI.Entities;
using CountieAPI.Models;
using CountieAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CountieAPI.Controllers
{
    [Route("katalog/kategorie")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public ActionResult CreateCategory([FromBody] CreateCategoryDto dto)
        {
            var newCategoryId = _categoryService.Create(dto);

            return Created($"katalog/kategorie/{newCategoryId}", null);
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetById([FromRoute] int id)
        {
            var categegory = _categoryService.GetById(id);

            return Ok(categegory);
        }
       
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetAll()
        {
            var categoriesDtos = _categoryService.GetAll();
            return Ok(categoriesDtos);
        }

        [HttpDelete("{id}")]
        public ActionResult<Category> Delete([FromRoute] int id)
        {
            var categoryId = _categoryService.Delete(id);
            return NoContent();
        }

    }
}
