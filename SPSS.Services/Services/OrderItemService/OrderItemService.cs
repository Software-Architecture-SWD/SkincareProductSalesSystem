using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SPSS.Entities;
using SPSS.Repository.Entities;
using SPSS.Repository.Repositories.OrderItemService;
using SPSS.Repository.UnitOfWork;
using SPSS.Service.Dto.Response;

namespace SPSS.Services.Services.OrderItemService
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task RemoveOrderItemAsync(int orderItemId)
        {
            return _unitOfWork.OrderItems.RemoveOrderItemAsync(orderItemId);
        }

        public Task<OrderItem> GetOrderItemByIdAsync(int orderItemId)
        {
            return _unitOfWork.OrderItems.GetOrderItemByIdAsync(orderItemId);
        }

        public async Task<List<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
        {
            return await _unitOfWork.OrderItems.GetOrderItemsByOrderIdAsync(orderId);
        }

        public async Task<bool> CreateOrderItemsAsync(int orderId, IEnumerable<CartItem> cartItems)
        {
            var orderItems = cartItems.Select(ci => new OrderItem
            {
                OrderId = orderId,
                ProductId = ci.ProductId,
                Quantity = ci.Quantity,
                TotalPrice = ci.TotalPrice
            }).ToList();

            var orderItemsResponse = _mapper.Map<IEnumerable<OrderItemResponse>>(orderItems);

            await _unitOfWork.OrderItems.AddOrderItemsAsync(orderItems);
            return true;
        }
    }
}
