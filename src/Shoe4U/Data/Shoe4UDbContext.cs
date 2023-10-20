using Shoe4U.Data.Models;

namespace Shoe4U.Data;

using Microsoft.EntityFrameworkCore;

public class Shoe4UDbContext : DbContext
{
    public Shoe4UDbContext(DbContextOptions<Shoe4UDbContext> options)
        : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Request> Requests { get; set; }

    public DbSet<Review> Reviews { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Fluent API
        
        // Set composite key
        modelBuilder.Entity<Order>()
            .HasKey(o => new { o.Id, o.UserId, o.ProductId });
        
        // Set foreign key
        modelBuilder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId);
        
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Product)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.ProductId);
        
        // Set composite key
        modelBuilder.Entity<Review>()
            .HasKey(r => new { r.Id, r.UserId, r.ProductId });
        
        // Set foreign key
        modelBuilder.Entity<Review>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId);
        
        modelBuilder.Entity<Review>()
            .HasOne(r => r.Product)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.ProductId);
    }
}