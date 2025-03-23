using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SPSS.Service.Services.FeedbackService;
using SPSS.Entities;
using SPSS.Dto.Request;
using SPSS.Dto.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SPSS.Repository.Entities;
using SPSS.Service.Dto.Response;
using SPSS.Service.Services.ProductService;

namespace SPSS.API.Controllers
{
    [Route("feedbacks")]
    [ApiController]
    public class FeedbackController(IFeedbackService _feedbackService, ILogger<FeedbackController> _logger) : ControllerBase
    {
        [HttpGet("product/{productId}/feedbacks")]
        public async Task<ActionResult<IEnumerable<FeedbackResponse>>> GetFeedbacksForProduct(int productId)
        {
            try
            {
                var feedbacks = await _feedbackService.GetFeedbacksByProductIdAsync(productId);
                return Ok(feedbacks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching feedbacks for product {ProductId}", productId);
                return StatusCode(500, "An error occurred while retrieving feedbacks.");
            }
        }

        [HttpGet("product/{productId}/paged")]
        public async Task<IActionResult> GetPagedFeedbacksForProduct(int productId, int page = 1, int pageSize = 10)
        {
            try
            {
                _logger.LogInformation("Fetching paged feedbacks for product ID {ProductId}, Page {Page}, PageSize {PageSize}", productId, page, pageSize);

                var result = await _feedbackService.GetPagedFeedbacksByProductIdAsync(productId, page, pageSize);

                var response = new
                {
                    Feedbacks = result.Feedbacks,
                    TotalCount = result.TotalCount,
                    CurrentPage = page,
                    PageSize = pageSize,
                    TotalPages = (int)Math.Ceiling(result.TotalCount / (double)pageSize)
                };

                _logger.LogInformation("Returning {Count} feedbacks on page {Page} out of {TotalPages} total pages.", result.Feedbacks.Count(), page, response.TotalPages);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching paged feedbacks for product {ProductId}", productId);
                return StatusCode(500, new { message = "An error occurred while retrieving paged feedbacks.", error = ex.Message });
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackResponse>> GetFeedbackById(int id)
        {
            try
            {
                var feedback = await _feedbackService.GetByIdAsync(id);
                if (feedback == null)
                {
                    return NotFound("Feedback not found.");
                }
                return Ok(feedback);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching feedback with ID {Id}", id);
                return StatusCode(500, "An error occurred while retrieving the feedback.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddFeedback([FromBody] FeedbackRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var feedback = new Feedback
                {
                    UserId = request.UserId,
                    ProductId = request.ProductId,
                    Rating = request.Rating,
                    Comment = request.Comment ?? string.Empty,
                    Created_at = DateTime.UtcNow
                };

                await _feedbackService.AddAsync(feedback);
                return CreatedAtAction(nameof(GetFeedbackById), new { id = feedback.Id }, feedback);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding feedback");
                return StatusCode(500, "An error occurred while adding the feedback.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFeedback(int id, [FromBody] FeedbackRequest request)
        {
            try
            {
                var existingFeedback = await _feedbackService.GetByIdAsync(id);
                if (existingFeedback == null)
                {
                    return NotFound("Feedback not found.");
                }

                existingFeedback.Rating = request.Rating;
                existingFeedback.Comment = request.Comment ?? string.Empty;

                await _feedbackService.UpdateAsync(existingFeedback);
                return Ok("Feedback updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating feedback with ID {Id}", id);
                return StatusCode(500, "An error occurred while updating the feedback.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            try
            {
                var product = await _feedbackService.GetByIdAsync(id);
                if (product == null)
                {
                    return NotFound(new { message = "Feedback not found." });
                }
                await _feedbackService.DeleteAsync(id);
                return Ok("Delete successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving the product.", error = ex.Message });
            }
        }
        [HttpPut("{id}/restore")]
        public async Task<IActionResult> RestoreFeedback(int id)
        {
            try
            {
                var feedback = await _feedbackService.GetByIdAsync(id);
                if (feedback == null)
                {
                    return NotFound(new { message = "Feedback not found." });
                }

                await _feedbackService.RestoreAsync(id);
                return Ok(new { message = "Feedback restored successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error restoring feedback with ID {Id}", id);
                return StatusCode(500, new { message = "An error occurred while restoring the feedback.", error = ex.Message });
            }
        }
    }
}