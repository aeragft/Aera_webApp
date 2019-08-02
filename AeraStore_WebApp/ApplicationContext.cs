using AeraStore_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AeraStore_WebApp
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasKey(t => t.Id);

            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<Order>().HasMany(o => o.Itens).WithOne(o => o.Order);
            modelBuilder.Entity<Order>().HasOne(o => o.Client).WithOne(c => c.Order).HasForeignKey<Client>(c => c.Id).IsRequired();

            modelBuilder.Entity<ItemOrder>().HasKey(t => t.Id);
            modelBuilder.Entity<ItemOrder>().HasOne(t => t.Order);
            modelBuilder.Entity<ItemOrder>().HasOne(t => t.Product);

            modelBuilder.Entity<Client>().HasKey(t => t.Id);
            modelBuilder.Entity<Client>().HasOne(t => t.Order);
        }
    }
}
