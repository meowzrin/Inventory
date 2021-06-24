using Microsoft.EntityFrameworkCore;

namespace Inventory.domain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
          
        {
        }
        public DbSet<Products> products { get; set; }
    }
}
