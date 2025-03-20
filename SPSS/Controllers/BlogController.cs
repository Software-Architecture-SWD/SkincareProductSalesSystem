using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Entities;
using SPSS.Service.Dto.Request;
using SPSS.Service.Dto.Response;
using SPSS.Service.Services.BlogService;

namespace SPSS.API.Controllers
{
    [Route("blogs")]
    [ApiController]
    public class BlogController(IMapper _mapper, IBlogService _blogService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromForm] BlogRequest blogRequest)
        {
            try
            {
                var blog = _mapper.Map<Blog>(blogRequest);
                await _blogService.AddAsync(blog);
                var blogResponse = _mapper.Map<BlogResponse>(blog);
                return Ok(blogResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the blog.", error = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetBlogList(int page = 1, int pageSize = 10)
        {
            try
            {
                var (blogs, totalCount) = await _blogService.GetPagedBlogsAsync(page, pageSize);
                if (!blogs.Any())
                {
                    return NotFound(new { message = "No blogs found." });
                }
                var blogResponses = _mapper.Map<IEnumerable<BlogResponse>>(blogs);
                return Ok(new { blogResponses, totalCount, page, pageSize });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving blogs.", error = ex.Message });
            }
        }
        [HttpDelete("{id}/removal")]
        public async Task<IActionResult> SoftDeleteBlog(int id)
        {
            try
            {
                await _blogService.SoftDeleteAsync(id);
                return Ok(new { message = "Blog soft-deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while soft-deleting the blog.", error = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            try
            {
                await _blogService.DeleteAsync(id);
                return Ok(new { message = "Blog deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the blog.", error = ex.Message });
            }
        }
        [HttpPut("{id}/restoration")]
        public async Task<IActionResult> RestoreBlog(int id)
        {
            try
            {
                await _blogService.RestoreAsync(id);
                return Ok(new { message = "Blog restored successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while restoring the blog.", error = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            try
            {
                var blog = await _blogService.GetByIdAsync(id);
                if (blog == null)
                {
                    return NotFound(new { message = "Blog not found." });
                }
                var blogResponse = _mapper.Map<BlogResponse>(blog);
                return Ok(blogResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving the blog.", error = ex.Message });
            }
        }
    }
}
