using System;
using System.ComponentModel.DataAnnotations;

namespace BeautyParlourManagementSystemAPI.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        public int ProductCost { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductDescription { get; set; }

        public int StockQuantity { get; set; }
    }
}