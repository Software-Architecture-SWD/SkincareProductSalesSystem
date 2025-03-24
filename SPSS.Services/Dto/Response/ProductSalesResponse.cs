using SPSS.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPSS.Service.Dto.Response
{
    public class ProductSalesByQuantityResponse
    {
        public int Id { get; set; }
        public int TotalQuantity { get; set; }
        public ProductResponse Product { get; set; }
    }

    public class ProductSalesBySalesResponse
    {
        public int Id { get; set; }
        public decimal TotalSales { get; set; }
        public ProductResponse Product { get; set; }
    }
}
