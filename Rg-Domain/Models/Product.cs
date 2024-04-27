using Rg_Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Rg_Domain.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }

        public int Type { get; set; }
    }
}