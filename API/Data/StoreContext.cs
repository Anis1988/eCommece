using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Product>().Property(p =>p.Name).IsRequired();
            builder.Entity<Product>().Property(p =>p.PictureUrl).IsRequired();
            builder.Entity<Product>().Property(p =>p.Price).IsRequired();

            base.OnModelCreating(builder);
            builder.Entity<ProductBrand>().Property(p =>p.Name).IsRequired();

            base.OnModelCreating(builder);
            builder.Entity<ProductType>().Property(p =>p.Name).IsRequired();
        }
    }
}
