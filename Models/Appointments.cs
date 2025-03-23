using System;
using System.ComponentModel.DataAnnotations;

namespace BeautyParlourManagementSystemAPI.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }

        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; }

        public DateTime AppointmentDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string AppointmentStatus { get; set; }

        [Required]
        [MaxLength(100)]
        public string AppointmentRemark { get; set; }
    }
}

