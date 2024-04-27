namespace Rg_Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Product { get; set; }

        IOrderRepository Order { get; set; }

        IOrderProductRepository OrderProduct { get; set; }

        int Complete();
    }
}