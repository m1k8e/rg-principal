using Rg_Business.Interfaces;
using Rg_Domain.Models;
using Rg_Service.Interfaces;

namespace Rg_Service
{
    public class ProductService : IProductService
    {
        private readonly IProductBusiness productBusiness;

        public ProductService(IProductBusiness _productBusiness)
        {
            productBusiness = _productBusiness;
        }

        public void Insert(Product entity)
        {
            productBusiness.Insert(entity);
        }

        public void Delete(Product entity)
        {
            productBusiness.Delete(entity);
        }

        public Product GetByID(int id)
        {
            return productBusiness.GetByID(id);
        }

        public IEnumerable<Product> Get()
        {
            return productBusiness.Get();
        }

        public void Update(Product entity)
        {
            productBusiness.Update(entity);
        }

        public IEnumerable<Product> GetExtras()
        {
            return productBusiness.GetExtras();
        }

        public IEnumerable<Product> GetSandwich()
        {
            return productBusiness.GetSandwich();
        }
    }
}