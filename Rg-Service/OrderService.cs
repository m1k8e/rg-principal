using Rg_Business.Interfaces;
using Rg_Domain.Dto;
using Rg_Domain.Models;
using Rg_Service.Interfaces;

namespace Rg_Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderBusiness orderBusiness;

        public OrderService(IOrderBusiness _orderBusiness)
        {
            orderBusiness = _orderBusiness;
        }

        public Order CreateOrder(Order entity)
        {
            return orderBusiness.Insert(entity);
        }

        public void Delete(int orderId)
        {
            orderBusiness.Delete(orderId);
        }

        public Order GetByID(int id)
        {
            return orderBusiness.GetByID(id);
        }

        public IEnumerable<Order> GetOrders()
        {
            return orderBusiness.Get();
        }

        public void Update(Order entity)
        {
            orderBusiness.Update(entity);
        }

        public Order CreateOrder(CreateOrderDto createOrderDto)
        {
            return orderBusiness.CreateOrder(createOrderDto);
        }

        public IEnumerable<GetOrderDto> GetAllOrders()
        {
            return orderBusiness.GetAllOrders();
        }
    }
}