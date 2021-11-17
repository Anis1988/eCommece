using System.Linq;
using System.Reflection;
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
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in builder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));

                    foreach (var property in properties)
                    {
                        builder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
                    }
                }
            }
            base.OnModelCreating(builder);
            builder.Entity<Product>().Property(p =>p.Name).IsRequired();
            builder.Entity<Product>().Property(p =>p.PictureUrl).IsRequired();
            builder.Entity<Product>().Property(p =>p.Price).IsRequired();
            builder.Entity<Product>().Property(p =>p.Price).HasColumnType("decimal(18,2)");

            base.OnModelCreating(builder);
            builder.Entity<ProductBrand>().Property(p =>p.Name).IsRequired();

            base.OnModelCreating(builder);
            builder.Entity<ProductType>().Property(p =>p.Name).IsRequired();


        }
    }
}
