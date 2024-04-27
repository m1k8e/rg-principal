using Rg_Domain.Dto;
using Rg_Domain.Models;

namespace Rg_Business.Interfaces
{
    public interface IOrderBusiness
    {
        Order GetByID(int id);

        IEnumerable<Order> Get();

        Order Insert(Order entity);

        void Delete(int orderId);

        void Update(Order entity);

        Order CreateOrder(CreateOrderDto createOrderDto);

        IEnumerable<GetOrderDto> GetAllOrders();
    }
}