using WowRoads.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Place> Place { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Agent> Agent { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Guide> Guide { get; set; }
    }
}