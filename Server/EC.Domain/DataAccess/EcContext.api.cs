using EC.Domain.Tables;
using Microsoft.EntityFrameworkCore;

namespace EC.Domain.DataAccess
{
    public partial class EcContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable(mb => mb.IsTemporal());
        }
    }
}
