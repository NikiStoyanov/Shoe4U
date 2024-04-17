namespace Shoe4U.Controllers;

using Data;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        var products = new List<ProductDetailsViewModel>();

        foreach (var productId in productIds)
        {
            products.Add(await this.data.Products
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
                .FirstOrDefaultAsync());
        }
        return this.View();
    }

    [HttpGet]
	public IActionResult Confirmation() => this.View();
}
