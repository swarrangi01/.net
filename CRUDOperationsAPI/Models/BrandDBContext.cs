using Microsoft.EntityFrameworkCore;

namespace CRUDOperationsAPI.Models
{
    public class BrandDBContext : DbContext
    {

        public BrandDBContext(DbContextOptions<BrandDBContext> options) : base(options)
        {


        }

        public DbSet<Brands> Brands { get; set; }

    }
}
