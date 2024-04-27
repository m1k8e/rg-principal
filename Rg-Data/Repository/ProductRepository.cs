using Rg_Data.Base;
using Rg_Data.Interfaces;
using Rg_Domain.Enums;
using Rg_Domain.Models;

namespace Rg_Data.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(GoodHamburguerContext context) : base(context)
        {
        }

        public override void Insert(Product entity)
        {
            base.Insert(entity);
        }

        public override void Delete(Product entity)
        {
            base.Delete(entity);
        }

        public Product GetByID(int id)
        {
            return base.GetByID(id);
        }

        public IEnumerable<Product> Get()
        {
            return base.Get();
        }

        public override void Update(Product entity)
        {
            base.Update(entity);
        }

        public IEnumerable<Product> GetExtras()
        {
            return base.Get().Where(p => p.Type != (int)ProductType.Sandwich);
        }

        public IEnumerable<Product> GetSandwich()
        {
            return GetByProductType(ProductType.Sandwich);
        }

        private IEnumerable<Product> GetByProductType(ProductType productType)
        {
            return base.Get().Where(p => p.Type == (int)productType);
        }

        public virtual IEnumerable<Product> GetByIDs(IEnumerable<int> ids)
        {
            return base.dbSet.Where(e => ids.Contains(e.ProductId));
        }
    }
}