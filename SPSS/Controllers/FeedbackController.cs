using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SPSS.Service.Services.FeedbackService;
using SPSS.Entities;
using SPSS.Dto.Request;
using SPSS.Dto.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SPSS.Service.Dto.Response;
using SPSS.Repository.Entities;

namespace SPSS.API.Controllers
{
    [Route("feedbacks")]
    [ApiController]
    public class FeedbacksController(IFeedbackService feedbackService, ILogger<FeedbacksController> logger) : ControllerBase
    {
        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetFeedbacksByProduct(int productId)
        {
            try
            {
                var feedbacks = await feedbackService.GetFeedbacksByProductIdAsync(productId);
                return Ok(new { message = "Feedbacks retrieved successfully.", data = feedbacks });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching feedbacks for product {ProductId}", productId);
                return StatusCode(500, new { message = "An error occurred while retrieving feedbacks." });
            }
        }

        [HttpGet("product/{productId}/paged")]
        public async Task<IActionResult> GetPagedFeedbacksByProduct(int productId, int page = 1, int pageSize = 10)
        {
            try
            {
                var result = await feedbackService.GetPagedFeedbacksByProductIdAsync(productId, page, pageSize);

                var response = new
                {
                    message = "Paged feedbacks retrieved successfully.",
                    data = result.Feedbacks,
                    totalCount = result.TotalCount,
                    currentPage = page,
                    pageSize = pageSize,
                    totalPages = (int)Math.Ceiling(result.TotalCount / (double)pageSize)
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching paged feedbacks for product {ProductId}", productId);
                return StatusCode(500, new { message = "An error occurred while retrieving paged feedbacks.", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedbackById(int id)
        {
            try
            {
                var feedback = await feedbackService.GetByIdAsync(id);
                if (feedback == null)
                {
                    return NotFound(new { message = "Feedback not found." });
                }
                return Ok(new { message = "Feedback retrieved successfully.", data = feedback });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching feedback with ID {Id}", id);
                return StatusCode(500, new { message = "An error occurred while retrieving the feedback.", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddFeedback([FromBody] FeedbackRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid input.", errors = ModelState });
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

                await feedbackService.AddAsync(feedback);
                return CreatedAtAction(nameof(GetFeedbackById), new { id = feedback.Id }, new { message = "Feedback added successfully.", data = feedback });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error adding feedback");
                return StatusCode(500, new { message = "An error occurred while adding the feedback.", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeedback(int id, [FromBody] FeedbackRequest request)
        {
            try
            {
                var existingFeedback = await feedbackService.GetByIdAsync(id);
                if (existingFeedback == null)
                {
                    return NotFound(new { message = "Feedback not found." });
                }

                existingFeedback.Rating = request.Rating;
                existingFeedback.Comment = request.Comment ?? string.Empty;

                await feedbackService.UpdateAsync(existingFeedback);
                return Ok(new { message = "Feedback updated successfully." });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error updating feedback with ID {Id}", id);
                return StatusCode(500, new { message = "An error occurred while updating the feedback.", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            try
            {
                var feedback = await feedbackService.GetByIdAsync(id);
                if (feedback == null)
                {
                    return NotFound(new { message = "Feedback not found." });
                }

                await feedbackService.DeleteAsync(id);
                return Ok(new { message = "Feedback deleted successfully." });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error deleting feedback with ID {Id}", id);
                return StatusCode(500, new { message = "An error occurred while deleting the feedback.", error = ex.Message });
            }
        }

        [HttpPut("{id}/restore")]
        public async Task<IActionResult> RestoreFeedback(int id)
        {
            try
            {
                var feedback = await feedbackService.GetByIdAsync(id);
                if (feedback == null)
                {
                    return NotFound(new { message = "Feedback not found." });
                }

                await feedbackService.RestoreAsync(id);
                return Ok(new { message = "Feedback restored successfully." });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error restoring feedback with ID {Id}", id);
                return StatusCode(500, new { message = "An error occurred while restoring the feedback.", error = ex.Message });
            }
        }
    }
}
