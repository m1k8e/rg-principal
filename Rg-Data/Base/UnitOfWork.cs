using Rg_Data.Interfaces;

namespace Rg_Data.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GoodHamburguerContext context;
        public IProductRepository Product { get; set; }
        public IOrderRepository Order { get; set; }
        public IOrderProductRepository OrderProduct { get; set; }

        public UnitOfWork(GoodHamburguerContext DbContext,
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            IOrderProductRepository orderProduct
            )
        {
            this.context = DbContext;
            this.Product = productRepository;
            this.Order = orderRepository;
            this.OrderProduct = orderProduct;
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
    }
}