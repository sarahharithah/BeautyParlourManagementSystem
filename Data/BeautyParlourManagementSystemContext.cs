using Microsoft.EntityFrameworkCore;
using BeautyParlourManagementSystemAPI.Models;

namespace BeautyParlourManagementSystemAPI.Data
{
    public class BeautyParlourManagementSystemAPIContext : DbContext
    {
        public BeautyParlourManagementSystemAPIContext(DbContextOptions<BeautyParlourManagementSystemAPIContext> options) : base(options) { }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}