using eCommerce.Enitites;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext (DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }   
    }
}
