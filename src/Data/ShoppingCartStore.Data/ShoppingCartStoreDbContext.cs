namespace ShoppingCartStore.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using ShoppingCartStore.Models;

    public class ShoppingCartStoreDbContext : IdentityDbContext<Customer>
    {
        public ShoppingCartStoreDbContext(DbContextOptions<ShoppingCartStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Cart> Carts{ get; set; }

        public DbSet<Item> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cart>()
                .HasOne(c => c.Customer)
                .WithOne(c => c.Cart)
                .HasForeignKey<Cart>(b => b.CustomerId);

            builder.Entity<Item>()
                .HasOne(i => i.Product);

            builder.Entity<Item>()
                .HasOne(i => i.Cart);

            base.OnModelCreating(builder);
        }
    }
}
