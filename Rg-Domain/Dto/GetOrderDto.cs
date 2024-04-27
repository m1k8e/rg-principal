using Rg_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rg_Domain.Dto
{
    public class GetOrderDto
    {
        public Order Order { get; set; } = null!;

        public List<Product> Products { get; set; }
    }
}