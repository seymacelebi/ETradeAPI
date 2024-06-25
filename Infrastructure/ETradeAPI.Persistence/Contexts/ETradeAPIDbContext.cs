using ETradeAPI.Domain.Entities;
using ETradeAPI.Domain.Entities.Common;
using ETradeAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
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
    public DbSet<ProductReview> ProductReview { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Wishlist> Wishlists { get; set; }
    public DbSet<WishlistItem> WishlistItems { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<ProductSupplier> ProductSuppliers { get; set; }

    public DbSet<UserSession> UserSessions { get; set; }
    public DbSet<ProductTag> ProductTags { get; set; }
    public DbSet<WarehouseLocation> WarehouseLocations { get; set; }
    public DbSet<InventoryMovement> InventoryMovements { get; set; }
    public DbSet<ReturnRequest> ReturnRequests { get; set; }
    public DbSet<OrderFulfillment> OrderFulfillments { get; set; }
    public DbSet<CustomerPreference> CustomerPreferences { get; set; }
    public DbSet<LoyaltyProgram> LoyaltyPrograms { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<SalesReport> SalesReports { get; set; }
    public DbSet<CustomerAnalytics> CustomerAnalytics { get; set; }
    public DbSet<Refund> Refunds { get; set; }
    public DbSet<Invoice> Invoices { get; set; }

    public DbSet<RecentlyViewedProduct> RecentlyViewedProducts { get; set; }


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

        //modelBuilder.Entity<ProductVariant>()
        //  .HasMany(x => x.Options)
        //  .WithOne(o => o.ProductVariant)
        //  .HasForeignKey(d => d.ProductVariantId);

        builder.Entity<ProductSupplier>()
               .HasKey(ps => new { ps.ProductId, ps.SupplierId });

        builder.Entity<ProductSupplier>()
            .HasOne(ps => ps.Product)
            .WithMany(p => p.ProductSuppliers)
            .HasForeignKey(ps => ps.ProductId);

        builder.Entity<ProductSupplier>()
            .HasOne(ps => ps.Supplier)
            .WithMany(s => s.ProductSuppliers)
            .HasForeignKey(ps => ps.SupplierId);

        builder.Entity<AppUser>()
        .HasOne(a => a.Customer)
        .WithOne(c => c.AppUser)
        .HasForeignKey<Customer>(c => c.AppUserId);

        builder.Entity<RecentlyViewedProduct>()
            .HasOne(b => b.Product)
            .WithMany(a => a.RecentlyViewedProducts)
            .HasForeignKey(b => b.ProductId);

        // UserSession varlığı için birincil anahtar tanımı
        builder.Entity<UserSession>()
            .HasKey(us => us.Id);

        // UserSession ile AppUser arasındaki ilişki tanımı
        builder.Entity<UserSession>()
            .HasOne(us => us.User)
            .WithMany()
            .HasForeignKey(us => us.UserId);

        // ProductTag - Product ilişkisinin tanımı
        builder.Entity<ProductTag>()
            .HasOne(pt => pt.Product)
            .WithMany(p => p.ProductTags)
            .HasForeignKey(pt => pt.ProductId);

        // InventoryMovement - Product ve WarehouseLocation ilişkilerinin tanımı
        builder.Entity<InventoryMovement>()
            .HasOne(im => im.Product)
            .WithMany()
            .HasForeignKey(im => im.ProductId);

        builder.Entity<InventoryMovement>()
            .HasOne(im => im.WarehouseLocation)
            .WithMany(wl => wl.InventoryMovements)
            .HasForeignKey(im => im.WarehouseId);

        // ReturnRequest - Order ve Product ilişkilerinin tanımı
        builder.Entity<ReturnRequest>()
            .HasOne(rr => rr.Order)
            .WithMany()
            .HasForeignKey(rr => rr.OrderId);

        builder.Entity<ReturnRequest>()
            .HasOne(rr => rr.Product)
            .WithMany()
            .HasForeignKey(rr => rr.ProductId);


        // OrderFulfillment - Order ve WarehouseLocation ilişkilerinin tanımı
        builder.Entity<OrderFulfillment>()
            .HasOne(of => of.Order)
            .WithMany(o => o.OrderFulfillments)
            .HasForeignKey(of => of.OrderId);

        builder.Entity<OrderFulfillment>()
            .HasOne(of => of.WarehouseLocation)
            .WithMany()
            .HasForeignKey(of => of.WarehouseId);

        // CustomerPreference - Customer ilişkisinin tanımı
        builder.Entity<CustomerPreference>()
            .HasOne(cp => cp.Customer)
            .WithMany(c => c.CustomerPreferences)
            .HasForeignKey(cp => cp.CustomerId);

        // LoyaltyProgram - Customer ilişkisinin tanımı
        builder.Entity<LoyaltyProgram>()
            .HasOne(lp => lp.Customer)
            .WithMany(c => c.LoyaltyPrograms)
            .HasForeignKey(lp => lp.CustomerId);

        // CustomerAnalytics - Customer ilişkisinin tanımı
        builder.Entity<CustomerAnalytics>()
            .HasOne(ca => ca.Customer)
            .WithMany()
            .HasForeignKey(ca => ca.CustomerId);

        // Refund - Order ilişkisinin tanımı
        builder.Entity<Refund>()
            .HasOne(r => r.Order)
            .WithMany(o => o.Refunds)
            .HasForeignKey(r => r.OrderId);

        // Invoice - Order ilişkisinin tanımı
        builder.Entity<Invoice>()
            .HasOne(i => i.Order)
            .WithMany(o => o.Invoices)
            .HasForeignKey(i => i.OrderId);

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