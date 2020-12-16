using Microsoft.EntityFrameworkCore;

namespace Confectionery.DAL.EF
{
    public class ConfectioneryDbContext : DbContext
    {
        public DbSet<Entities.Product> Products { get; set; }
        public DbSet<Entities.Category> Categories { get; set; }
        public DbSet<Entities.Order> Orders { get; set; }
        public DbSet<Entities.OrderItem> OrderItems { get; set; }

        public ConfectioneryDbContext(DbContextOptions<ConfectioneryDbContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(o=>o.Order);
            modelBuilder.Entity<Entities.OrderItem>()
                .HasOne(o => o.Product);
            modelBuilder.Entity<Entities.Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category);
        }

    }
}
