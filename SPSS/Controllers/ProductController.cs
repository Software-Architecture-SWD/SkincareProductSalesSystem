using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using SPSS.Dto.Request;
using SPSS.Dto.Response;
using SPSS.Entities;
using SPSS.Service.Services.FirebaseStorageService;
using SPSS.Service.Services.ProductService;
using SPSS.Services.Services.OrderItemService;
using System.IO;
using SPSS.Service.Dto.Request;

namespace SPSS.API.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController(
        IFirebaseStorageService firebaseStorageService,
        IMapper mapper,
        IProductService productService,
        IOrderItemService orderItemService
    ) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] ProductRequest productRequest)
        {
            try
            {
                var brand = await productService.GetBrandByNameAsync(productRequest.BrandName);
                var category = await productService.GetCategoryByNameAsync(productRequest.CategoryName);

                var product = mapper.Map<Product>(productRequest);
                product.BrandId = brand.Id;
                product.CategoryId = category.Id;
                product.OriginalPrice = product.Price;

                if (productRequest.ImageFile != null)
                {
                    using var stream = productRequest.ImageFile.OpenReadStream();
                    var fileName = $"{Guid.NewGuid()}_{productRequest.ImageFile.FileName}";
                    product.ImageUrl = await firebaseStorageService.UploadImageAsync(stream, fileName);
                }

                await productService.AddAsync(product);
                var productResponse = mapper.Map<ProductResponse>(product);
                return Ok(new { message = "Product created successfully.", data = productResponse });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the product.", error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedProducts([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var (products, totalCount) = await productService.GetPagedProductsAsync(page, pageSize);
                if (!products.Any())
                {
                    return NotFound(new { message = "No products found." });
                }

                var productResponses = mapper.Map<IEnumerable<ProductResponse>>(products);
                return Ok(new { message = "Products retrieved successfully.", data = productResponses, totalCount, page, pageSize });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving products.", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var product = await productService.GetByIdAsync(id);
                if (product == null)
                {
                    return NotFound(new { message = "Product not found." });
                }

                var productResponse = mapper.Map<ProductResponse>(product);
                return Ok(new { message = "Product retrieved successfully.", data = productResponse });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving the product.", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromForm] ProductRequestUpdate productRequest)
        {
            try
            {
                var product = await productService.GetByIdAsync(id);
                if (product == null)
                {
                    return NotFound(new { message = "Product not found." });
                }

                mapper.Map(productRequest, product);

                product.Price = productRequest.Price ?? product.Price;
                product.StockQuantity = productRequest.StockQuantity ?? product.StockQuantity;

                if (productRequest.ImageFile != null)
                {
                    using var stream = productRequest.ImageFile.OpenReadStream();
                    var fileName = productRequest.ImageFile.FileName;
                    product.ImageUrl = await firebaseStorageService.UploadImageAsync(stream, fileName);
                }

                await productService.UpdateAsync(id, product);
                return Ok(new { message = "Product updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the product.", error = ex.Message });
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await productService.GetByIdAsync(id);
                if (product == null)
                {
                    return NotFound(new { message = "Product not found." });
                }

                await productService.DeleteAsync(id);
                return Ok(new { message = "Product deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the product.", error = ex.Message });
            }
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetFilteredProducts(
            [FromQuery] string? categoryName,
            [FromQuery] string? brandName,
            [FromQuery] string? sortPrice,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                var (products, totalCount) = await productService.GetFilteredProductsAsync(categoryName, brandName, sortPrice, page, pageSize);

                if (!products.Any())
                {
                    return NotFound(new { message = "No products found with the given filters." });
                }

                var productResponses = mapper.Map<IEnumerable<ProductResponse>>(products);
                return Ok(new { message = "Filtered products retrieved successfully.", data = productResponses, totalCount, page, pageSize });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving filtered products.", error = ex.Message });
            }
        }

        [HttpGet("total")]
        public async Task<IActionResult> GetTotalProducts()
        {
            try
            {
                var total = await productService.GetTotalProducts();
                return Ok(new { message = "Total products retrieved successfully.", totalProducts = total });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error.", error = ex.Message });
            }
        }

        [HttpGet("topsales")]
        public async Task<IActionResult> GetTopSoldProducts([FromQuery] int topN, [FromQuery] int option)
        {
            try
            {
                IEnumerable<object> products;

                switch (option)
                {
                    case 1:
                        products = await orderItemService.GetTopSalesByRevenue(topN);
                        break;
                    case 2:
                        products = await orderItemService.GetTopSalesByQuantity(topN);
                        break;
                    default:
                        return BadRequest(new { message = "Invalid option. Use 1 for revenue or 2 for quantity." });
                }

                if (!products.Any())
                {
                    return NotFound(new { message = "No top-selling products found." });
                }

                return Ok(new { message = "Top-selling products retrieved successfully.", data = products });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving top-selling products.", error = ex.Message });
            }
        }
    }
}
