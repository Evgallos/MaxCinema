using MaxCinema.Models;
using Microsoft.EntityFrameworkCore;

namespace MaxCinema.Data
{
    public class MCinemaContext :DbContext
    {
        public MCinemaContext(DbContextOptions<MCinemaContext> options) : base(options) { }
        
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderRow> OrderRows { get; set; }
        public DbSet<Customer> Customers { get; set; }
        
        
        
    }
}
