
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;

namespace Demo.DataAccess.Models
{
    public class WebDbContext : DbContext
    {
        public WebDbContext(DbContextOptions<WebDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Brand>()
                .ToTable(nameof(Brand));
            builder.Entity<Product>()
                .ToTable(nameof(Product));
            builder.Entity<Category>()
                .ToTable(nameof(Category));
            builder.Entity<Color>()
                .ToTable(nameof(Color));

            builder.Entity<ProductColor>(entity =>
            {
                entity.ToTable(nameof(ProductColor));
                entity.HasKey(x => new { x.ColorId, x.ProductId });
                entity.HasOne(e => e.Product).WithMany(e => e.ProductColors).HasForeignKey(x => x.ProductId);
                entity.HasOne(e => e.Color).WithMany(e => e.ProductColors).HasForeignKey(x => x.ColorId);
            });
        }

        protected DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }

    }
}
