using AeraStore_WebApp.Models;
using JetBrains.Annotations;
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
        }
    }
}
