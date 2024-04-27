using Rg_Domain.Dto;
using Rg_Domain.Models;

namespace Rg_Business.Interfaces
{
    public interface IOrderValidation
    {
        decimal ReturnDiscount(List<Product> products);

        bool IsSingleValidOrder(List<OrderProductDto> orderProductDtos);
    }
}