﻿namespace SPSS.Dto.Response
{
    public class ProductResponse
    {
        public int Id { get; set; }

        public string BrandName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int StockQuantity { get; set; }
        public string? ImageUrl { get; set; }
        public string? Ingredients { get; set; }
        public string? UsageInstructions { get; set; }
        public string? Benefits { get; set; }
        public bool isDelete { get; set; } = false;
    }
}
