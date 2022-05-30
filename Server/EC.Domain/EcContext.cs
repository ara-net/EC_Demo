using Microsoft.EntityFrameworkCore;


namespace EC.Domain
{
    public class EcContext : DbContext
    {
        public EcContext(DbContextOptions<EcContext> options)
            : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Baskets> Baskets { get; set; }
        public DbSet<BasketDetail> BasketDetail { get; set; }
        public DbSet<BasketHistory> BasketHistory { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}