using System.Collections.Generic;
using System.Threading.Tasks;
using SPSS.Entities;
using SPSS.Repository.Entities;
using SPSS.Repository.Repositories.OrderItemService;
using SPSS.Repository.UnitOfWork;

namespace SPSS.Services.Services.OrderItemService
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddOrderItemAsync(OrderItem orderItem)
        {
            return _unitOfWork.OrderItems.AddOrderItemAsync(orderItem);
        }

        public Task RemoveOrderItemAsync(int orderItemId)
        {
            return _unitOfWork.OrderItems.RemoveOrderItemAsync(orderItemId);
        }

        public Task<OrderItem> GetOrderItemByIdAsync(int orderItemId)
        {
            return _unitOfWork.OrderItems.GetOrderItemByIdAsync(orderItemId);
        }

        public Task<List<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
        {
            return _unitOfWork.OrderItems.GetOrderItemsByOrderIdAsync(orderId);
        }
    }
}
