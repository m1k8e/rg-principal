using System.ComponentModel.DataAnnotations;

namespace Rg_Domain.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public string Customer { get; set; } = null!;

        public decimal Discount { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal FinalPrice { get; set; }
    }
}