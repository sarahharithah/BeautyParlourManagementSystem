using System;
using System.ComponentModel.DataAnnotations;

namespace BeautyParlourManagementSystemAPI.Models
{
    public class Services
    {
        [Key]
        public int ServiceID { get; set; }

        [Required]
        [MaxLength(100)]
        public string ServiceName { get; set; }

        public int ServiceCost { get; set; }

        [Required]
        [MaxLength(100)]
        public string ServiceDescription { get; set; }
    }
}

