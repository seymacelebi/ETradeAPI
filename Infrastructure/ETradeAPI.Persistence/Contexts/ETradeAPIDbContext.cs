using ETradeAPI.Domain.Entities;
using ETradeAPI.Domain.Entities.Common;
using ETradeAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence.Contexts;

public class ETradeAPIDbContext : IdentityDbContext<AppUser, AppRole, string>
{
    public ETradeAPIDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Endpoint> Endpoints { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductVariant> ProductVariants { get; set; }
    public DbSet<VariantOption> VariantOptions { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Shipment> Shipments { get; set; } // New DbSet
    public DbSet<Discount> Discounts { get; set; } // New DbSet
    public DbSet<ProductDiscount> ProductDiscounts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Order>()
            .HasKey(b => b.Id);

  

        builder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId);

        builder.Entity<Address>()
           .HasOne(a => a.Customer)
           .WithMany(c => c.Addresses)
           .HasForeignKey(a => a.CustomerId);


        builder.Entity<ProductVariant>()
            .HasMany(x => x.Options)
            .WithOne(o => o.ProductVariant)
            .HasForeignKey(d => d.ProductVariantId);

        // Order - OrderItem ilişkisinin tanımı
        builder.Entity<Order>()
            .HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId);

        // OrderItem - Product ilişkisinin tanımı
        builder.Entity<OrderItem>()
            .HasOne(oi => oi.Product)
            .WithMany()
            .HasForeignKey(oi => oi.ProductId);

        // Order - Payment ilişkisinin tanımı
        builder.Entity<Order>()
            .HasMany(o => o.Payments)
            .WithOne(p => p.Order)
            .HasForeignKey(p => p.OrderId);
        //basket-basketıtem ilişkisi
        builder.Entity<Basket>()
           .HasOne(c => c.Customer)
           .WithOne(cu => cu.Basket)
           .HasForeignKey<Basket>(c => c.CustomerId)
           .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<BasketItem>()
            .HasOne(ci => ci.Basket)
            .WithMany(c => c.BasketItems)
            .HasForeignKey(ci => ci.BasketId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<BasketItem>()
            .HasOne(ci => ci.Product)
            .WithMany()
            .HasForeignKey(ci => ci.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        //shipment
        builder.Entity<Shipment>()
           .HasOne(s => s.Order)
           .WithMany(o => o.Shipments)
           .HasForeignKey(s => s.OrderId)
           .OnDelete(DeleteBehavior.Cascade);

        // Configuring Discount and ProductDiscount relationships
        builder.Entity<ProductDiscount>()
            .HasOne(pd => pd.Product)
            .WithMany(p => p.ProductDiscounts)
            .HasForeignKey(pd => pd.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ProductDiscount>()
            .HasOne(pd => pd.Discount)
            .WithMany(d => d.ProductDiscounts)
            .HasForeignKey(pd => pd.DiscountId)
            .OnDelete(DeleteBehavior.Cascade);
        //user-customer relationships
        builder.Entity<Customer>()
          .HasOne(c => c.AppUser)
          .WithMany(u => u.Customers)
          .HasForeignKey(c => c.AppUserId)
          .OnDelete(DeleteBehavior.Cascade);

        //modelBuilder.Entity<ProductVariant>()
        //  .HasMany(x => x.Options)
        //  .WithOne(o => o.ProductVariant)
        //  .HasForeignKey(d => d.ProductVariantId);

        base.OnModelCreating(builder);

        
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        //ChangeTracker : Entityler üzerinden yapılan değişiklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.
        var datas = ChangeTracker
                .Entries<BaseEntity>();
        foreach (var data in datas)
        {
            _ = data.State switch
            {
                EntityState.Added => data.Entity.CreateDate = DateTime.UtcNow,
                EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                _ => DateTime.UtcNow
            };
        }


        return await base.SaveChangesAsync(cancellationToken);

    }
}