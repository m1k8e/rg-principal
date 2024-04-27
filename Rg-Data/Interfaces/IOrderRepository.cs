using Rg_Domain.Models;

namespace Rg_Data.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        IEnumerable<OrderProduct> GetAllOrders();
    }
}