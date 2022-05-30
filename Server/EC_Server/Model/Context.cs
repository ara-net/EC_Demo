using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EC_Server.Model
{
    public class EiContext : DbContext
    {
        public EiContext(DbContextOptions<EiContext> options)
            : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Baskets> Baskets { get; set; }
        public DbSet<BasketDetail> BasketDetail { get; set; }
        public DbSet<BasketHistory> BasketHistory { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("EiDb");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}