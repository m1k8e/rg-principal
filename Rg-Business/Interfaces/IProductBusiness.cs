using Rg_Domain.Models;

namespace Rg_Business.Interfaces
{
    public interface IProductBusiness
    {
        Product GetByID(int id);

        IEnumerable<Product> Get();

        void Insert(Product entity);

        void Delete(Product entity);

        void Update(Product entity);

        IEnumerable<Product> GetExtras();

        IEnumerable<Product> GetSandwich();
    }
}