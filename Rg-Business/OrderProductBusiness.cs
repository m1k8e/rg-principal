using Rg_Business.Interfaces;
using Rg_Data.Interfaces;
using Rg_Domain.Enums;
using Rg_Domain.Models;

namespace Rg_Business
{
    public class OrderProductBusiness : IOrderProductBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IOrderProductRepository OrderProduct;

        public OrderProductBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            OrderProduct = unitOfWork.OrderProduct;
        }

        public OrderProduct Insert(OrderProduct entity)
        {
            OrderProduct.Insert(entity);
            unitOfWork.Complete();
            return entity;
        }

        public void Delete(OrderProduct entity)
        {
            OrderProduct.Delete(entity);
            unitOfWork.Complete();
        }

        public OrderProduct GetByID(int id)
        {
            return OrderProduct.GetByID(id);
        }

        public IEnumerable<OrderProduct> Get()
        {
            return OrderProduct.Get();
        }

        public void Update(OrderProduct entity)
        {
            OrderProduct.Update(entity);
        }

        public void InsertRange(IEnumerable<OrderProduct> entity)
        {
            OrderProduct.InsertRange(entity);
        }
    }
}