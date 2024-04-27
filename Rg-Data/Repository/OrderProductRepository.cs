using Rg_Data.Base;
using Rg_Data.Interfaces;
using Rg_Domain.Enums;
using Rg_Domain.Models;

namespace Rg_Data.Repository
{
    public class OrderProductRepository : GenericRepository<OrderProduct>, IOrderProductRepository
    {
        public OrderProductRepository(GoodHamburguerContext context) : base(context)
        {
        }

        public override void Insert(OrderProduct entity)
        {
            base.Insert(entity);
        }

        public override void Delete(OrderProduct entity)
        {
            base.Delete(entity);
        }

        public OrderProduct GetByID(int id)
        {
            return base.GetByID(id);
        }

        public IEnumerable<OrderProduct> Get()
        {
            return base.Get();
        }

        public override void Update(OrderProduct entity)
        {
            base.Update(entity);
        }

        public void InsertRange(IEnumerable<OrderProduct> entity)
        {
            base.dbSet.AddRange(entity);
        }

        public IEnumerable<OrderProduct> GetByOrder(int orderId)
        {
            return base.context.OrderProduct.Where(x => x.OrderId == orderId);
        }
    }
}