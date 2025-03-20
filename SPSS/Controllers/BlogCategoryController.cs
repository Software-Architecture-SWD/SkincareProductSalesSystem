using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Entities;
using SPSS.Service.Dto.Request;
using SPSS.Service.Dto.Response;
using SPSS.Service.Services.BlogCategoryService;

namespace SPSS.API.Controllers
{
    [Route("blogcategory")]
    [ApiController]
    public class BlogCategoryController(IMapper _mapper, IBlogCategoryService _blogCategoryService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateBlogCategory([FromForm] BlogCategoryRequest blogCategoryRequest)
        {
            try
            {
                var blogCategory = _mapper.Map<BlogCategory>(blogCategoryRequest);
                await _blogCategoryService.AddAsync(blogCategory);
                var blogCategoryResponse = _mapper.Map<BlogCategoryResponse>(blogCategory);
                return Ok(blogCategoryResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the blog category.", error = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetBlogCategoryList()
        {
            try
            {
                var blogCategories = await _blogCategoryService.GetAllAsync();
                if (!blogCategories.Any())
                {
                    return NotFound(new { message = "No blog categories found." });
                }
                var blogCategoryResponses = _mapper.Map<IEnumerable<BlogCategoryResponse>>(blogCategories);
                return Ok(blogCategoryResponses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving blog categories.", error = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlogCategory(int id, [FromForm] BlogCategoryRequest blogCategoryRequest)
        {
            try
            {
                var blogCategory = await _blogCategoryService.GetByIdAsync(id);
                if (blogCategory == null)
                {
                    return NotFound(new { message = "Blog category not found." });
                }
                _mapper.Map(blogCategoryRequest, blogCategory);
                await _blogCategoryService.UpdateAsync(blogCategory);
                var blogCategoryResponse = _mapper.Map<BlogCategoryResponse>(blogCategory);
                return Ok(blogCategoryResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the blog category.", error = ex.Message });
            }
        }
        [HttpDelete("{id}/removal")]
        public async Task<IActionResult> SoftDeleteBlogCategory(int id)
        {
            try
            {
                await _blogCategoryService.SoftDeleteAsync(id);
                return Ok(new { message = "Blog category soft-deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while soft-deleting the blog category.", error = ex.Message });
            }
        }
    }
}
