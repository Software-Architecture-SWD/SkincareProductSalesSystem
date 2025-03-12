using Microsoft.AspNetCore.Mvc;
using SPSS.Dto;
using SPSS.Entities;
using AutoMapper;
using System;
using System.IO;
using System.Threading.Tasks;
using SPSS.Dto.Request;
using SPSS.Dto.Response;
using SPSS.Service.Services.FirebaseStorageService;
using SPSS.Service.Services.ProductService;
using Microsoft.EntityFrameworkCore;

namespace SPSS.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController( IMapper _mapper, IProductService _productService) : ControllerBase
    {

        

        [HttpGet]
        public async Task<IActionResult> GetProductList(int page = 1, int pageSize = 10)
        {
            try
            {
                var (products, totalCount) = await _productService.GetPagedProductsAsync(page, pageSize);

                if (!products.Any())
                {
                    return NotFound(new { message = "No products found." });
                }

                return Ok(new { products, totalCount, page, pageSize });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving products.", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var product = await _productService.GetByIdAsync(id);
                if (product == null)
                {
                    return NotFound(new { message = "Product not found." });
                }

                var productResponse = _mapper.Map<ProductResponse>(product);
                return Ok(productResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving the product.", error = ex.Message });
            }
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetFilteredProducts(
            string? categoryName,
            string? brandName,
            string? sortPrice,
            int page = 1,
            int pageSize = 10)
        {
            try
            {
                var (products, totalCount) = await _productService.GetFilteredProductsAsync(categoryName, brandName, sortPrice, page, pageSize);

                if (!products.Any())
                {
                    return NotFound(new { message = "No products found with the given filters." });
                }

                var productResponses = _mapper.Map<IEnumerable<ProductResponse>>(products);
                return Ok(new { products = productResponses, totalCount, page, pageSize });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving filtered products.", error = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequest productRequest)
        {
            try
            {
                var product = await _productService.CreateProductAsync(productRequest);
                var productResponse = _mapper.Map<ProductResponse>(product);

                return CreatedAtAction(nameof(GetProduct), new { id = productResponse.Id }, productResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the product.", error = ex.Message });
            }
        }
    }
}