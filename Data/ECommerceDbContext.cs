using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
namespace E_commercebyifza.Data


    public class ECommerceDbContext : DbContext
    {
       
    public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
        : base(options)
        { 
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }

}

