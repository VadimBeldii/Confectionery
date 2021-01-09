using Microsoft.EntityFrameworkCore;

namespace Confectionery.DAL.EF
{
    public class ConfectioneryDbContext : DbContext
    {
        public DbSet<Entities.Product> Products { get; set; }
        public DbSet<Entities.Category> Categories { get; set; }
        public DbSet<Entities.Order> Orders { get; set; }
        public DbSet<Entities.OrderItem> OrderItems { get; set; }
        public DbSet<Entities.Statistics> Statistics { get; set; }

        public ConfectioneryDbContext(DbContextOptions<ConfectioneryDbContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Order>()
                .Property(o => o.Id).ValueGeneratedOnAdd();           
            modelBuilder.Entity<Entities.OrderItem>()
                .Property(o => o.Id).ValueGeneratedOnAdd();            
            modelBuilder.Entity<Entities.Statistics>()
                .Property(s => s.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Entities.Order>()
                .HasMany(o => o.orderItems)
                .WithOne()
                .HasForeignKey(o => o.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
