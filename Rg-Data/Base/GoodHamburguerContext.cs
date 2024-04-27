using Microsoft.EntityFrameworkCore;
using Rg_Domain.Models;
using System.Data;
using System.Security.Cryptography;

namespace Rg_Data.Base
{
    public partial class GoodHamburguerContext : DbContext
    {
        public GoodHamburguerContext()
        {
        }

        public GoodHamburguerContext(DbContextOptions<GoodHamburguerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderProduct> OrderProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>(e =>
            {
                e.HasKey(b => b.OrderProductId);
                e.Property(p => p.OrderProductId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Order>(e =>
            {
                e.HasKey(b => b.OrderId);
                e.Property(p => p.OrderId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Product>(e =>
            {
                e.HasKey(b => b.ProductId);
                e.Property(p => p.ProductId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderProduct>().ToTable("OrderProduct");
            //modelBuilder.Entity<Product>(entity =>
            //{
            //    //entity.HasMany(p => p.Order).WithMany(e => e.Product).UsingEntity("OrderProduct");
            //    entity.Property(e => e.ProductName).HasMaxLength(500);
            //});
            //modelBuilder.Entity<Order>(entity =>
            //{
            //    //entity.HasMany(p => p.Product).WithMany(e => e.Order).UsingEntity("OrderProduct");
            //    entity.Property(e => e.Customer).HasMaxLength(500);
            //});
        }
    }
}