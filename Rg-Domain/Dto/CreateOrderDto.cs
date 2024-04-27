using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rg_Domain.Dto
{
    public class CreateOrderDto
    {
        public string Customer { get; set; } = null!;

        public List<OrderProductDto> Products { get; set; }
    }
}