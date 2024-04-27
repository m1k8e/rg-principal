using Rg_Domain.Models;

namespace Rg_Data.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetExtras();

        IEnumerable<Product> GetSandwich();

        IEnumerable<Product> GetByIDs(IEnumerable<int> ids);
    }
}