﻿using Microsoft.AspNetCore.Http;

namespace SPSS.Dto.Request
{
    public class ProductRequest
    {

        public string BrandName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal? Price { get; set; }
        public int? StockQuantity { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string? Ingredients { get; set; }
        public string? UsageInstructions { get; set; }
        public string? Benefits { get; set; }
    }
}
