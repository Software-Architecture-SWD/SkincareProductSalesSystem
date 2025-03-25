using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Service.Dto.Request;
using SPSS.Service.Dto.Response;
using SPSS.Service.Services.CategoryService;

namespace SPSS.API.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await categoryService.GetAllAsync();
                if (categories == null || !categories.Any())
                {
                    return NotFound(new { message = "No categories found." });
                }

                var categoryResponses = mapper.Map<IEnumerable<CategoryResponse>>(categories);
                return Ok(categoryResponses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while retrieving categories.",
                    error = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await categoryService.GetByIdAsync(id);
                if (category == null)
                {
                    return NotFound(new { message = "Category not found." });
                }

                var categoryResponse = mapper.Map<CategoryResponse>(category);
                return Ok(categoryResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while retrieving the category.",
                    error = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryRequest categoryRequest)
        {
            try
            {
                var category = await categoryService.GetByIdAsync(id);
                if (category == null)
                {
                    return NotFound(new { message = "Category not found." });
                }

                mapper.Map(categoryRequest, category);
                await categoryService.UpdateAsync(id, category);
                return Ok(new { message = "Category updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while updating the category.",
                    error = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var category = await categoryService.GetByIdAsync(id);
                if (category == null)
                {
                    return NotFound(new { message = "Category not found." });
                }

                await categoryService.DeleteAsync(id);
                return Ok(new { message = "Category deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while deleting the category.",
                    error = ex.Message
                });
            }
        }
    }
}
