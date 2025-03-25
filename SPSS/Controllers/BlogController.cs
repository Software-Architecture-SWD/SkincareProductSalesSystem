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
    public class BlogsController(IMapper mapper, IBlogService blogService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromForm] BlogRequest blogRequest)
        {
            try
            {
                var blog = mapper.Map<Blog>(blogRequest);
                await blogService.AddAsync(blog);
                var blogResponse = mapper.Map<BlogResponse>(blog);
                return Ok(blogResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while creating the blog.",
                    error = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedBlogs(int page = 1, int pageSize = 10)
        {
            try
            {
                var (blogs, totalCount) = await blogService.GetPagedBlogsAsync(page, pageSize);
                if (!blogs.Any())
                {
                    return NotFound(new { message = "No blogs found." });
                }

                var blogResponses = mapper.Map<IEnumerable<BlogResponse>>(blogs);
                return Ok(new
                {
                    blogResponses,
                    totalCount,
                    page,
                    pageSize
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while retrieving blogs.",
                    error = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            try
            {
                var blog = await blogService.GetByIdAsync(id);
                if (blog == null)
                {
                    return NotFound(new { message = "Blog not found." });
                }

                var blogResponse = mapper.Map<BlogResponse>(blog);
                return Ok(blogResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while retrieving the blog.",
                    error = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteBlog(int id)
        {
            try
            {
                await blogService.SoftDeleteAsync(id);
                return Ok(new { message = "Blog soft-deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while soft-deleting the blog.",
                    error = ex.Message
                });
            }
        }

        [HttpDelete("{id}/permanent")]
        public async Task<IActionResult> PermanentlyDeleteBlog(int id)
        {
            try
            {
                await blogService.DeleteAsync(id);
                return Ok(new { message = "Blog permanently deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while deleting the blog.",
                    error = ex.Message
                });
            }
        }

        [HttpPut("{id}/restore")]
        public async Task<IActionResult> RestoreBlog(int id)
        {
            try
            {
                await blogService.RestoreAsync(id);
                return Ok(new { message = "Blog restored successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while restoring the blog.",
                    error = ex.Message
                });
            }
        }
    }
}
