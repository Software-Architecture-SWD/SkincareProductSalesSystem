using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Repository.Entities;
using SPSS.Service.Dto.Request;
using SPSS.Service.Dto.Response;
using SPSS.Service.Services.BlogContentService;

namespace SPSS.API.Controllers
{
    [Route("blog-contents")]
    [ApiController]
    public class BlogContentsController(IMapper mapper, IBlogContentService blogContentService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllBlogContents()
        {
            try
            {
                var blogContents = await blogContentService.GetAllAsync();
                if (!blogContents.Any())
                {
                    return NotFound(new { message = "No blog contents found." });
                }

                var blogContentResponses = mapper.Map<IEnumerable<BlogContentResponse>>(blogContents);
                return Ok(blogContentResponses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while retrieving blog contents.",
                    error = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogContent([FromForm] BlogContentRequest blogContentRequest)
        {
            try
            {
                var blogContent = mapper.Map<BlogContent>(blogContentRequest);
                await blogContentService.AddAsync(blogContent);
                var blogContentResponse = mapper.Map<BlogContentResponse>(blogContent);
                return Ok(blogContentResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while creating the blog content.",
                    error = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlogContent(int id, [FromForm] BlogContentRequest blogContentRequest)
        {
            try
            {
                var blogContent = mapper.Map<BlogContent>(blogContentRequest);
                blogContent.Id = id;

                await blogContentService.UpdateAsync(blogContent);
                var blogContentResponse = mapper.Map<BlogContentResponse>(blogContent);
                return Ok(blogContentResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while updating the blog content.",
                    error = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogContent(int id)
        {
            try
            {
                await blogContentService.DeleteAsync(id);
                return Ok(new { message = "Blog content deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while deleting the blog content.",
                    error = ex.Message
                });
            }
        }
    }
}
