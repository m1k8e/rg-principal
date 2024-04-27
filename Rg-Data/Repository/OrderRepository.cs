using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Rg_Data.Base;
using Rg_Data.Interfaces;
using Rg_Domain.Dto;
using Rg_Domain.Models;

namespace Rg_Data.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(GoodHamburguerContext context) : base(context)
        {
        }

        public override void Insert(Order entity)
        {
            base.Insert(entity);
        }

        public override void Delete(Order entity)
        {
            base.Delete(entity);
        }

        public Order GetByID(int id)
        {
            return base.GetByID(id);
        }

        public IEnumerable<Order> Get()
        {
            return base.Get();
        }

        public override void Update(Order entity)
        {
            base.Update(entity);
        }

        public IEnumerable<OrderProduct> GetAllOrders()
        {
            return base.context.OrderProduct
                   .Include(op => op.Order)
                   .Include(op => op.Product);
        }
    }
}