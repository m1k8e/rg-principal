using Rg_Domain.Models;

namespace Rg_Data.Interfaces
{
    public interface IOrderProductRepository : IGenericRepository<OrderProduct>
    {
        void InsertRange(IEnumerable<OrderProduct> entity);

        IEnumerable<OrderProduct> GetByOrder(int orderId);
    }
}