using Rg_Business.Interfaces;
using Rg_Domain.Dto;
using Rg_Domain.Enums;
using Rg_Domain.Models;
using System.Collections.Generic;

namespace Rg_Business
{
    public class OrderValidation : IOrderValidation
    {
        public OrderValidation()
        {
        }

        public decimal ReturnDiscount(List<Product> products)
        {
            var hasFries = HasProductType(products, ProductType.Fries);
            var hasDrink = HasProductType(products, ProductType.SoftDrink);
            if (hasFries && hasDrink)
                return 20;
            else if (hasFries)
                return 10;
            else if (hasDrink)
                return 15;

            return 0;
        }

        public bool IsSingleValidOrder(List<OrderProductDto> orderProductDtos)
        {
            var queryDuplicates = orderProductDtos.GroupBy(x => x.IdProduct)
              .Where(g => g.Count() > 1)
              .Select(y => y.Key)
              .ToList();

            return !(orderProductDtos.Any(p => p.Quantity > 1) || queryDuplicates.Any());
        }

        private bool HasProductType(List<Product> products, ProductType productName)
        {
            return products.Any(p => p.Type == (int)productName);
        }
    }
}