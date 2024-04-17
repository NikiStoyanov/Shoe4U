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
	public IActionResult Confirmation() => this.View();
}
