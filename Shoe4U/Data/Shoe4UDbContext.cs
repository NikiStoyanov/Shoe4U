namespace Shoe4U.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

public class Shoe4UDbContext : IdentityDbContext<User>
{
    public Shoe4UDbContext(DbContextOptions<Shoe4UDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<Review> Reviews { get; set; }

    public DbSet<Message> Messages { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderProduct> OrderProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Product)
            .WithMany(p => p.Reviews)
            .HasForeignKey(r => r.ProductId);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId);

        modelBuilder.Entity<OrderProduct>()
            .HasKey(op => new { op.OrderId, op.ProductId });

        modelBuilder.Entity<OrderProduct>()
            .HasOne(op => op.Order)
            .WithMany(o => o.OrderProducts)
            .HasForeignKey(op => op.OrderId);

        modelBuilder.Entity<OrderProduct>()
            .HasOne(op => op.Product)
            .WithMany(p => p.OrderProducts)
            .HasForeignKey(op => op.ProductId);

        var roleId = Guid.NewGuid().ToString();

        modelBuilder.Entity<IdentityRole>()
            .HasData(new IdentityRole
            {
                Id = roleId,
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                ConcurrencyStamp = roleId
            });

        var adminId = Guid.NewGuid().ToString();

        var admin = new User()
        {
            Id = adminId,
            Email = "admin@shoe4u.com",
            NormalizedEmail = "ADMIN@SHOE4U.COM",
            EmailConfirmed = true,
            Name = "Иван Петров",
            UserName = "admin@shoe4u.com",
            NormalizedUserName = "ADMIN@SHOE4U.COM"
		};

        PasswordHasher<User> ph = new PasswordHasher<User>();
        admin.PasswordHash = ph.HashPassword(admin, "Admin_Shoe4U_2024");

        modelBuilder.Entity<User>()
            .HasData(admin);

        modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = adminId
            });

        var userId = Guid.NewGuid().ToString();

        var user = new User()
        {
            Id = userId,
            Email = "user@shoe4u.com",
            NormalizedEmail = "USER@SHOE4U.COM",
            EmailConfirmed = true,
            Name = "Петър Георгиев",
            UserName = "user@shoe4u.com",
            NormalizedUserName = "USER@SHOE4U.COM"
        };

        user.PasswordHash = ph.HashPassword(user, "User_Shoe4U_2024");

        modelBuilder.Entity<User>()
            .HasData(user);
    }
}
