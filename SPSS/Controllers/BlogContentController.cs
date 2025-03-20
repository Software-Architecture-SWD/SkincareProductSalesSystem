using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SPSS.Repository.Entities;
using SPSS.Service.Dto.Request;
using SPSS.Service.Dto.Response;
using SPSS.Service.Services.BlogContentService;

namespace SPSS.API.Controllers
{
    [Route("blogcontent")]
    [ApiController]
    public class BlogContentController(IMapper _mapper, IBlogContentService _blogContentService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBlogContentList()
        {
            try
            {
                var blogContents = await _blogContentService.GetAllAsync();
                if (!blogContents.Any())
                {
                    return NotFound(new { message = "No blog contents found." });
                }
                var blogContentResponses = _mapper.Map<IEnumerable<BlogContentResponse>>(blogContents);
                return Ok(blogContentResponses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving blog contents.", error = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlogContent([FromForm] BlogContentRequest blogContentRequest)
        {
            try
            {
                var blogContent = _mapper.Map<BlogContent>(blogContentRequest);
                await _blogContentService.AddAsync(blogContent);
                var blogContentResponse = _mapper.Map<BlogContentResponse>(blogContent);
                return Ok(blogContentResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the blog content.", error = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlogContent(int id, [FromForm] BlogContentRequest blogContentRequest)
        {
            try
            {
                var blogContent = _mapper.Map<BlogContent>(blogContentRequest);
                blogContent.Id = id;
                await _blogContentService.UpdateAsync(blogContent);
                var blogContentResponse = _mapper.Map<BlogContentResponse>(blogContent);
                return Ok(blogContentResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the blog content.", error = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogContent(int id)
        {
            try
            {
                await _blogContentService.DeleteAsync(id);
                return Ok(new { message = "Blog content deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the blog content.", error = ex.Message });
            }
        }
    }
}
