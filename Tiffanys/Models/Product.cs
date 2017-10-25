using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tiffanys.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double Cost { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double RetailPrice { get; set; }

        public ICollection<Item> Items { get; set; }

        private static double TotalRevenue { get; set; }
        private static double TotalCost { get; set; }

        public Product()
        {
            
        }
    }
}
