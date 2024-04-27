using Rg_Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rg_Domain.Models
{
    public class OrderProduct
    {
        [Key]
        public int OrderProductId { get; set; }

        [ForeignKey("FK_OrderProduct_Order")]
        public int OrderId { get; set; }

        [ForeignKey("FK_OrderProduct_Product")]
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}