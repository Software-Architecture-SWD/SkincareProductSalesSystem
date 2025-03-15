using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Service.Dto.Request;
using SPSS.Service.Dto.Response;
using SPSS.Service.Services.BrandService;
using SPSS.Service.Services.CategoryService;

namespace SPSS.API.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoryController(ICategoryService _categoryService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCategoryList()
        {
            try
            {
                var listCategory = await _categoryService.GetAllAsync();
                if (listCategory == null)
                {
                    return NotFound(new { message = "No categories found." });
                }
                return Ok(listCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving categories.", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(id);
                if (category == null)
                {
                    return NotFound(new { message = "Category not found." });
                }

                var categoryResponse = _mapper.Map<CategoryResponse>(category);
                return Ok(categoryResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving the category.", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryRequest categoryRequest)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(id);
                if (category == null)
                {
                    return NotFound(new { message = "Category not found." });
                }
                _mapper.Map(categoryRequest, category);
                await _categoryService.UpdateAsync(id, category);
                return Ok("Update successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving the category.", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(id);
                if (category == null)
                {
                    return NotFound(new { message = "Category not found." });
                }
                await _categoryService.DeleteAsync(id);
                return Ok("Delete successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving the category.", error = ex.Message });
            }
        }
    }
}
