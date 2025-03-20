using Microsoft.Extensions.Logging;
using SPSS.Entities;
using SPSS.Repository.UnitOfWork;
using SPSS.Service.Services.BlogService;

namespace SPSS.Service.Services.BlogService
{
    public class BlogService(IUnitOfWork _unitOfWork, ILogger<BlogService> _logger) : IBlogService
    {
        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all blogs.");
                return await _unitOfWork.Blogs.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all blogs.");
                throw new Exception("An error occurred while retrieving blogs.", ex);
            }
        }
        public async Task<(IEnumerable<Blog> Blogs, int TotalCount)> GetPagedBlogsAsync(int page, int pageSize)
        {
            try
            {
                _logger.LogInformation("Fetching all Blogs for pagination.");
                var allBlogs = await _unitOfWork.Blogs.GetAllAsync();
                var totalCount = allBlogs.Count();
                var pagedBlogs = allBlogs.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                _logger.LogInformation("Returning {Count} Blogs out of {TotalCount} total.", pagedBlogs.Count, totalCount);
                return (pagedBlogs, totalCount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching paged Blogs.");
                throw;
            }
        }
        public async Task AddAsync(Blog p)
        {
            try
            {
                _logger.LogInformation("Adding a new blog");
                await _unitOfWork.Blogs.AddAsync(p);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding blog");
                throw;
            }
        }
        public async Task UpdateAsync(Blog p)
        {
            try
            {
                _logger.LogInformation("Updating a blog");
                await _unitOfWork.Blogs.UpdateAsync(p);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating blog");
                throw;
            }
        }
        public async Task DeleteAsync(int id)
        {
            try
            {
                _logger.LogInformation("Deleting a blog");
                await _unitOfWork.Blogs.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting blog");
                throw;
            }
        }
        public async Task SoftDeleteAsync(int id)
        {
            try
            {
                _logger.LogInformation("Soft deleting a blog");
                await _unitOfWork.Blogs.SoftDeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error soft deleting blog");
                throw;
            }
        }
        public async Task RestoreAsync(int id)
        {
            try
            {
                _logger.LogInformation("Restoring a blog");
                await _unitOfWork.Blogs.RestoreAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error restoring blog");
                throw;
            }
        }
        public async Task<Blog?> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Fetching blog by ID {Id}", id);
                return await _unitOfWork.Blogs.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching blog by ID {Id}", id);
                throw;
            }
        }

    }
}
