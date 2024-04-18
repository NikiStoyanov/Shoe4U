namespace Shoe4U.Data;

using Enums;
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
            Basket = "1",
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
            Basket = "1; 2",
            Name = "Петър Георгиев",
            UserName = "user@shoe4u.com",
            NormalizedUserName = "USER@SHOE4U.COM"
        };

        user.PasswordHash = ph.HashPassword(user, "User_Shoe4U_2024");

        modelBuilder.Entity<User>()
            .HasData(user);

        modelBuilder.Entity<Message>()
	        .HasData(
		        new Message()
		        {
	                Id = 1,
	                Name = "Иван Петров",
	                Email = "ivan.petrov@gmail.com",
	                Subject = "Запитване",
	                Content = "Зелените ботуши налични ли са?"
				},
				new Message()
		        {
			        Id = 2,
			        Name = "Георги Ангелов",
			        Email = "georgi.angelov@gmail.com",
			        Subject = "Размер на мокасините",
			        Content = "Бежавите мокасини налични ли са 37 номер?"
				});

		modelBuilder.Entity<Product>()
	        .HasData(
		        new Product() 
		        {
	                Id = 1,
			        Name = "Зимни ботуши",
			        Category = ProductCategory.Male,
			        Description = "Зимни ботуши, идеални за студените месеци, с водоустойчива повърхност и топла подплата. Стилен дизайн, подходящ за всекидневието и разнообразни поводи. Издръжливи материали и удобна подметка за сигурност на различни повърхности. Насладете се на комфорт и топлина през зимата с тези модерни ботуши.",
			        Price = 85.99m,
			        Color = "Зелен",
			        Brand = "Adidas",
			        Material = "Велур",
			        Quantity = 3,
			        Size = "43",
	                CreatedOn = new DateTime(2024, 5, 20),
			        ImageUrl = "http://res.cloudinary.com/dthtmmyo8/image/upload/v1713120403/btu4yldkeb0h7qeobksc.jpg"
				}, 
		        new Product()
				{
                    Id = 2,
					Name = "Мокасини",
					Category = ProductCategory.Female,
					Description = "Мокасини с универсален стил, подходящи за всички сезони. Изработени от висококачествени материали, които осигуряват комфорт и издръжливост. Лек и гъвкав дизайн за удобство при носене през цялата година. Изберете мокасините за ежедневието си с увереност в стил и удобство.",
					Price = 47.99m,
					Color = "Розово и бяло",
					Brand = "Tendenz",
					Material = "Велур",
					Quantity = 1,
					Size = "37",
					CreatedOn = new DateTime(2024, 5, 10),
					ImageUrl = "http://res.cloudinary.com/dthtmmyo8/image/upload/v1713124891/pj6qwgbm7ldvi6nox00b.jpg"
				});

		modelBuilder.Entity<Review>()
			.HasData(
				new Review()
				{
					Id = 1,
					CreatedOn = new DateTime(2024, 5, 10, 21, 19, 00),
					UserId = userId,
                    ProductId = 1,
					Content = "Зимните ботуши са идеалният избор за студените дни! Удобни, топли и водоустойчиви - точно както обещават. Дизайнът им е стилен и мога да ги комбинирам с всякакви облекла. Супер съм доволен от покупката си!"
				},
				new Review()
				{
					Id = 2,
					CreatedOn = new DateTime(2024, 5, 15, 15, 23, 00),
					UserId = adminId,
					ProductId = 1,
					Content = "Зимните ботуши са моят спасител през студените месеци! Не само че са топли и удобни, но и изглеждат страхотно. Водоустойчивата повърхност наистина работи и ме уверява, че няма да ми стане студ нито на дъждовен ден. Със сигурност ще ги препоръчам на приятелите си!"
				},
				new Review()
				{
					Id = 3,
					CreatedOn = new DateTime(2024, 5, 17, 7, 41, 00),
					UserId = userId,
					ProductId = 2,
					Content = "Мокасините са просто невероятни! Нося ги всеки ден и се чувствам толкова комфортно в тях. Изработени са от качествени материали и изглеждат много стилно. Бих ги препоръчал на всеки, който търси удобство и елегантност в едно."
				},
				new Review()
				{
					Id = 4,
					CreatedOn = new DateTime(2024, 5, 19, 12, 37, 00),
					UserId = adminId,
					ProductId = 2,
					Content = "Мокасините са моят нов любим чифт обувки! Невероятно са удобни и меки, като втора кожа. Подходящи за носене през цялата година, те са перфектни за всекидневна употреба. Дизайнът им е класически, но все пак много стилен. Препоръчвам ги на всеки, който цени комфорта и качеството."
				});

		modelBuilder.Entity<Order>()
			.HasData(
				new Order()
				{
					Id = 1,
					UserId = userId,
					TotalSum = 133.98m,
					Address = "ул. \"Сан Стефано\" 1",
					PhoneNumber = "+359874526871"
				},
				new Order()
				{
					Id = 2,
					UserId = userId,
					TotalSum = 47.99m,
					Address = "ул. \"Княз Александър Батенберг\" 34",
					PhoneNumber = "+359878526011"
				},
				new Order()
				{
					Id = 3,
					UserId = adminId,
					TotalSum = 85.99m,
					Address = "ул. \"Опълченска\" 21",
					PhoneNumber = "+359874596507"
				});

		modelBuilder.Entity<OrderProduct>()
			.HasData(
				new OrderProduct()
				{
					OrderId = 1,
					ProductId = 1
				},
				new OrderProduct()
				{
					OrderId = 1,
					ProductId = 2
				},
				new OrderProduct()
				{
					OrderId = 2,
					ProductId = 2
				},
				new OrderProduct()
				{
					OrderId = 3,
					ProductId = 1
				});
	}
}
