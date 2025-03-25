using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Entities;
using SPSS.Service.Dto.Request;
using SPSS.Service.Dto.Response;
using SPSS.Service.Services.BlogCategoryService;

namespace SPSS.API.Controllers
{
    [Route("blog-categories")]
    [ApiController]
    public class BlogCategoriesController(IMapper mapper, IBlogCategoryService blogCategoryService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateBlogCategory([FromForm] BlogCategoryRequest blogCategoryRequest)
        {
            try
            {
                var blogCategory = mapper.Map<BlogCategory>(blogCategoryRequest);
                await blogCategoryService.AddAsync(blogCategory);
                var blogCategoryResponse = mapper.Map<BlogCategoryResponse>(blogCategory);
                return Ok(blogCategoryResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while creating the blog category.",
                    error = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogCategories()
        {
            try
            {
                var blogCategories = await blogCategoryService.GetAllAsync();
                if (!blogCategories.Any())
                {
                    return NotFound(new { message = "No blog categories found." });
                }

                var blogCategoryResponses = mapper.Map<IEnumerable<BlogCategoryResponse>>(blogCategories);
                return Ok(blogCategoryResponses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while retrieving blog categories.",
                    error = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlogCategory(int id, [FromForm] BlogCategoryRequest blogCategoryRequest)
        {
            try
            {
                var blogCategory = await blogCategoryService.GetByIdAsync(id);
                if (blogCategory == null)
                {
                    return NotFound(new { message = "Blog category not found." });
                }

                mapper.Map(blogCategoryRequest, blogCategory);
                await blogCategoryService.UpdateAsync(blogCategory);
                var blogCategoryResponse = mapper.Map<BlogCategoryResponse>(blogCategory);
                return Ok(blogCategoryResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while updating the blog category.",
                    error = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogCategory(int id)
        {
            try
            {
                await blogCategoryService.SoftDeleteAsync(id);
                return Ok(new { message = "Blog category deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while deleting the blog category.",
                    error = ex.Message
                });
            }
        }
    }
}
