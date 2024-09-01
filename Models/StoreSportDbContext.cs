using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Chapter_7.Models
{
    public class StoreSportDbContext:DbContext
    {
        public StoreSportDbContext(DbContextOptions<StoreSportDbContext> options)
            : base(options) { }


        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}

   





