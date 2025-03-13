using Microsoft.Extensions.Logging;
using SPSS.Entities;
using SPSS.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Services.BrandService
{
    public class BrandService(IUnitOfWork _unitOfWork, ILogger<BrandService> _logger) : IBrandService
    {
        public async Task AddAsync(Brand b)
        {
            try
            {
                _logger.LogInformation("Adding a new brand: {BrandName}", b.BrandName);
                await _unitOfWork.Brands.AddAsync(b);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding brand: {BrandName}", b.BrandName);
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                _logger.LogInformation("Deleting brand ID {Id}", id);
                var brand = await _unitOfWork.Brands.GetByIdAsync(id);
                if (brand == null)
                {
                    _logger.LogWarning("Brand with ID {Id} not found.", id);
                    throw new KeyNotFoundException($"Brand with ID {id} not found.");

                }
                else await _unitOfWork.Brands.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting brand ID {Id}", id);
                throw;
            }
        }

        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all products.");
                return await _unitOfWork.Brands.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all brands.");
                throw new Exception("An error occurred while retrieving brands.", ex);
            }
        }

        public async Task<Brand> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Fetching brand with ID {Id}", id);
                var brand = await _unitOfWork.Brands.GetByIdAsync(id);

                if (brand == null)
                {
                    _logger.LogWarning("Brand with ID {Id} not found.", id);
                    throw new KeyNotFoundException($"Brand with ID {id} not found.");
                }

                return brand;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching brand with ID {Id}", id);
                throw;
            }
        }

        public async Task<Brand> GetByNameAsync(string name)
        {
            try
            {
                _logger.LogInformation("Fetching brand with Name {Name}", name);
                var brand = await _unitOfWork.Brands.GetByNameAsync(name);

                if (brand == null)
                {
                    _logger.LogWarning("Brand with name {name} not found.", name);
                    throw new KeyNotFoundException($"Brand with name {name} not found.");
                }

                return brand;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching brand with name {name}", name);
                throw;
            }
        }

        public async Task UpdateAsync(int id, Brand b)
        {
            try
            {
                _logger.LogInformation("Updating brand ID {Id}", b.Id);
                var brand = await _unitOfWork.Brands.GetByIdAsync(id);
                if (brand == null)
                {
                    _logger.LogWarning("Brand with ID {Id} not found.", id);
                    throw new KeyNotFoundException($"Brand with ID {id} not found.");
                }
                await _unitOfWork.Brands.UpdateAsync(b);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating brand ID {Id}", b.Id);
                throw;
            }
        }
    }
}
