using Rg_Business.Interfaces;
using Rg_Data.Interfaces;
using Rg_Domain.Enums;
using Rg_Domain.Models;

namespace Rg_Business
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductRepository product;

        public ProductBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            product = unitOfWork.Product;
        }

        public void Insert(Product entity)
        {
            product.Insert(entity);
            unitOfWork.Complete();
        }

        public void Delete(Product entity)
        {
            product.Delete(entity);
            unitOfWork.Complete();
        }

        public Product GetByID(int id)
        {
            return product.GetByID(id);
        }

        public IEnumerable<Product> Get()
        {
            return product.Get();
        }

        public void Update(Product entity)
        {
            product.Update(entity);
        }

        public IEnumerable<Product> GetExtras()
        {
            return product.GetExtras();
        }

        public IEnumerable<Product> GetSandwich()
        {
            return product.GetSandwich();
        }
    }
}