namespace Shoe4U.Controllers;

using System.Security.Claims;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Orders;
using Models.Products;
using Models.Users;

public class OrdersController : Controller
{
    private readonly UserManager<User> userManager;
    private readonly Shoe4UDbContext data;

    public OrdersController(UserManager<User> userManager, Shoe4UDbContext data)
    {
        this.userManager = userManager;
        this.data = data;
    }

	[HttpGet]
	[Authorize]
	public async Task<IActionResult> Overview()
    {
        var user = await this.userManager.GetUserAsync(User);

        var productIds = user.Basket
            .Split("; ")
            .Where(p => p != "")
            .Select(int.Parse);

        var model = new CreateOrderInputModel();

        var products = new List<ProductDetailsViewModel>();

        foreach (var productId in productIds)
        {
            var product = await this.data.Products
                .Where(p => p.Id == productId)
                .Select(p => new ProductDetailsViewModel()
                {
                    Brand = p.Brand,
                    Color = p.Color,
                    Description = p.Description,
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Material = p.Material,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Size = p.Size
                })
                .FirstOrDefaultAsync();

            model.Products.Add(product);

            model.TotalPrice += product.Price;
        }

        return this.View(model);
    }

	[HttpPost]
	[Authorize]
	public async Task<IActionResult> Create(CreateOrderInputModel input)
	{
		var user = await this.userManager.GetUserAsync(User);

		var productIds = user.Basket
			.Split("; ")
			.Where(p => p != "")
			.Select(int.Parse);

		var order = new Order()
		{
            TotalSum = input.TotalPrice,
            Address = input.Address,
            PhoneNumber = input.PhoneNumber,
            UserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value
    };

        await this.data.Orders.AddAsync(order);
        await this.data.SaveChangesAsync();

		foreach (var id in productIds)
		{
			var product = await this.data.Products
				.SingleOrDefaultAsync(p => p.Id == id);

			product.Quantity--;

			if (product.Quantity == 0)
			{
				await this.data.Users.ForEachAsync(u =>
				{
					var products = u.Basket
						.Split("; ")
						.Where(p => p != "" && p != id.ToString())
						.ToList();

					u.Basket = string.Join("; ", products);
				});
			}
			
			var orderProduct = new OrderProduct()
			{
				OrderId = order.Id,
                ProductId = id,
			};

			await this.data.OrderProducts.AddAsync(orderProduct);
		}

		user.Basket = "";

		await this.data.SaveChangesAsync();

		return RedirectToAction("Confirmation");
	}

    [HttpGet]
    [Authorize]
    public IActionResult Confirmation() => this.View();

    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> All()
    {
        var orders = await this.data.Orders
            .Select(o => new OrderDetailsOutputModel()
            {
                Id = o.Id,
                TotalSum = o.TotalSum,
                Address = o.Address,
                PhoneNumber = o.PhoneNumber,
                UserId = o.UserId,
                User = this.data.Users
                    .Where(u => u.Id == o.UserId)
                    .Select(u => new UserDetailsViewModel()
                    {
                        Id = u.Id,
                        Name = u.Name,
                        Email = u.Email
                    })
                    .SingleOrDefault(),
                Products = new List<ProductDetailsViewModel>()
            })
            .ToListAsync();

        foreach (var order in orders)
        {
            var orderProducts = await this.data.OrderProducts
                .Where(op => op.OrderId == order.Id)
                .ToListAsync();

            foreach (var orderProduct in orderProducts)
            {
                var product = await this.data.Products
                    .Where(p => p.Id == orderProduct.ProductId)
                    .Select(product => new ProductDetailsViewModel()
                    {
                        Brand = product.Brand,
                        Color = product.Color,
                        Description = product.Description,
                        Id = product.Id,
                        ImageUrl = product.ImageUrl,
                        Material = product.Material,
                        Name = product.Name,
                        Price = product.Price,
                        Quantity = product.Quantity,
                        Size = product.Size
                    })
                    .FirstOrDefaultAsync();

                order.Products.Add(product);
            }
        }

        return this.View(orders);
    }
}
