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
    public class ProductsController(IFirebaseStorageService _firebaseStorageService, IMapper _mapper, IProductService _productService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] ProductRequest productRequest)
        {
            try
            {
                var product = _mapper.Map<Product>(productRequest);

                if (productRequest.ImageFile != null)
                {
                    using (var stream = productRequest.ImageFile.OpenReadStream())
                    {
                        var fileName = $"{Guid.NewGuid()}_{productRequest.ImageFile.FileName}";
                        product.ImageUrl = await _firebaseStorageService.UploadImageAsync(stream, fileName);
                    }
                }

                await _productService.AddAsync(product);
                var productResponse = _mapper.Map<ProductResponse>(product);
                return Ok(productResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the product.", error = ex.Message });
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> GetProductList()
        //{
        //    try
        //    {
        //        var listProduct = await _productService.GetAllAsync();
        //        if (listProduct == null)
        //        {
        //            return NotFound(new { message = "No products found." });
        //        }
        //        return Ok(listProduct);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = "An error occurred while retrieving products.", error = ex.Message });
        //    }
        //}

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
    }
}