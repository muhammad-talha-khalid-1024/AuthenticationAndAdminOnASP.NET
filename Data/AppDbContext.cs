using Microsoft.EntityFrameworkCore;
using MyFirstDotNetApp.Models;

namespace MyFirstDotNetApp.Data
{
    // general constructor
    // public class AppDbContext : DbContext
    // {
    //     public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    //     {
            
    //     }
    // }
    
    // primary constructor
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}