using Rg_Domain.Dto;
using Rg_Domain.Models;

namespace Rg_Service.Interfaces
{
    public interface IOrderService
    {
        Order GetByID(int id);

        IEnumerable<Order> GetOrders();

        Order CreateOrder(Order entity);

        void Delete(int orderId);

        void Update(Order entity);

        Order CreateOrder(CreateOrderDto createOrderDto);

        IEnumerable<GetOrderDto> GetAllOrders();
    }
}