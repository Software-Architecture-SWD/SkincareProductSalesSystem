using System.Collections.Generic;
using System.Threading.Tasks;
using SPSS.Entities;
using SPSS.Repository.Entities;
using SPSS.Service.Dto.Response;

namespace SPSS.Services.Services.OrderItemService
{
    public interface IOrderItemService
    {
        Task<bool> CreateOrderItemsAsync(int orderId, IEnumerable<CartItem> cartItems);
        Task RemoveOrderItemAsync(int orderItemId);
        Task<OrderItem> GetOrderItemByIdAsync(int orderItemId);
        Task<List<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);
        Task<IEnumerable<ProductSalesByQuantityResponse>> GetTopSalesByQuantity(int topN);
        Task<IEnumerable<ProductSalesBySalesResponse>> GetTopSalesByRevenue(int topN);
    }
}

