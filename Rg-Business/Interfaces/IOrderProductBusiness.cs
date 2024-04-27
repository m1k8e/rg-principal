using Rg_Domain.Dto;
using Rg_Domain.Models;

namespace Rg_Business.Interfaces
{
    public interface IOrderProductBusiness
    {
        OrderProduct GetByID(int id);

        IEnumerable<OrderProduct> Get();

        OrderProduct Insert(OrderProduct entity);

        void Delete(OrderProduct entity);

        void Update(OrderProduct entity);

        void InsertRange(IEnumerable<OrderProduct> entity);
    }
}