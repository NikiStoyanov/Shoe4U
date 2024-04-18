namespace Shoe4U.Controllers;

using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Data;
using Data.Enums;
using Data.Models;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Products;
using Models.Reviews;
using System.Security.Claims;

public class ProductsController : Controller
{
    private readonly Shoe4UDbContext data;
    private readonly UserManager<User> userManager;

    public ProductsController(Shoe4UDbContext data, UserManager<User> userManager)
    {
        this.data = data;
        this.userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        var model = new ProductsListingModel()
        {
            ListName = "Всички",
            Products = await this.GetProducts()
        };

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Males()
    {
        var model = new ProductsListingModel()
        {
            ListName = "Мъжки",
            Products = (await this.GetProducts())
                .Where(p => p.Category == ProductCategory.Male)
                .ToList()
        };

        return View("All", model);
    }

    [HttpGet]
    public async Task<IActionResult> Females()
    {
        var model = new ProductsListingModel()
        {
            ListName = "Дамски",
            Products = (await this.GetProducts())
                .Where(p => p.Category == ProductCategory.Female)
                .ToList()
        };

        return View("All", model);
    }

    [HttpGet]
    public async Task<IActionResult> Kids()
    {
        var model = new ProductsListingModel()
        {
            ListName = "Детски",
            Products = (await this.GetProducts())
                .Where(p => p.Category == ProductCategory.Kids)
                .ToList()
        };

        return View("All", model);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var user = await this.userManager.GetUserAsync(User);

        var product = await this.data.Products.SingleOrDefaultAsync(p => p.Id == id);

        var model = new CreateReviewInputModel
        {
            IsCurrentProductInCart = user?.Basket.Contains(id.ToString()) ?? false,
            Product = new ProductDetailsViewModel()
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
                Size = product.Size,
                Reviews = await this.data.Reviews
                    .Where(r => r.ProductId == id)
                    .Select(r => new ReviewDetailsOutputModel
                    {
                        CreatedOn = r.CreatedOn,
                        Content = r.Content,
                        UserName = this.data.Users
                            .SingleOrDefault(u => u.Id == r.UserId).Name
                    })
                    .ToListAsync()
            }
        };

        if (this.User.Identity.IsAuthenticated)
        {
            var orders = await this.data.Orders
                .Where(o => o.UserId == this.User.FindFirst(ClaimTypes.NameIdentifier).Value).ToListAsync();

            foreach (var order in orders)
            {
                var orderProducts = await this.data.OrderProducts
                    .Where(op => op.OrderId == order.Id && op.ProductId == id).ToListAsync();

                if (!model.IsCurrentProductPurchasedBefore)
                {
                    model.IsCurrentProductPurchasedBefore = orderProducts.Any();
                }
            }
        }
        
        return this.View(model);
    }

    [HttpGet]
	[Authorize(Roles = "Administrator")]
	public IActionResult Add() => this.View();

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Create(CreateProductInputModel input)
    {
        var fileName = Path.GetFileName(input.Image.FileName);
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", fileName);

        using var fileStream = new FileStream(filePath, FileMode.Create);

        await input.Image.CopyToAsync(fileStream);

        fileStream.Close();

        var account = new Account()
        {
	        Cloud = "dthtmmyo8",
	        ApiKey = "625294595751747",
	        ApiSecret = "nMC_6NR5C64ea1_iOVetG8XScAw"
        };

        var cloudinary = new Cloudinary(account);

        var imageParams = new ImageUploadParams()
        {
	        File = new FileDescription(filePath)
        };

        var result = await cloudinary.UploadAsync(imageParams);

        System.IO.File.Delete(filePath);

        var product = new Product
        {
            Name = input.Name,
            Category = (ProductCategory)input.Category,
            Description = input.Description,
            Price = input.Price,
            Color = input.Color,
            Brand = input.Brand,
            Material = input.Material,
            Quantity = input.Quantity,
            Size = input.Size,
            ImageUrl = result.Url.ToString()
        };

        await this.data.Products.AddAsync(product);

        await this.data.SaveChangesAsync();

        return RedirectToAction("Add");
    }

    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Edit(int id)
    {
        var recipe = await this.data.Products
            .Where(p => p.Id == id)
            .Select(p => new ProductDetailsViewModel()
            {
                Brand = p.Brand,
                Color = p.Color,
                CategoryInt = (int)p.Category,
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

        return View(recipe);
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Update(int id, ProductDetailsViewModel input)
    {
        var product = await this.data.Products
            .FirstOrDefaultAsync(r => r.Id == id);

        if (!this.User.IsInRole("Administrator"))
        {
            return BadRequest();
        }

        product.Name = input.Name;
        product.Category = (ProductCategory)input.CategoryInt;
        product.Description = input.Description;
        product.Price = input.Price;
        product.Color = input.Color;
        product.Material = input.Material;
        product.Brand = input.Brand;
        product.Size = input.Size;
        product.Quantity = input.Quantity;

        if (input.Image != null)
        {
            var fileName = Path.GetFileName(input.Image.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", fileName);

            using var fileStream = new FileStream(filePath, FileMode.Create);

            await input.Image.CopyToAsync(fileStream);

            fileStream.Close();

            var account = new Account()
            {
                Cloud = "dthtmmyo8",
                ApiKey = "625294595751747",
                ApiSecret = "nMC_6NR5C64ea1_iOVetG8XScAw"
            };

            var cloudinary = new Cloudinary(account);

            var imageParams = new ImageUploadParams()
            {
                File = new FileDescription(filePath)
            };

            var result = await cloudinary.UploadAsync(imageParams);

            System.IO.File.Delete(filePath);

            product.ImageUrl = result.Url.ToString();
        }

        await this.data.SaveChangesAsync();

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddToCart(string id)
    {
        var user = await this.userManager.GetUserAsync(User);

        var products = user.Basket.Split("; ").Where(p => p != "").ToList();

        if (!products.Contains(id))
        {
            products.Add(id);
        }
        
        user.Basket = string.Join("; ", products);

        await this.data.SaveChangesAsync();

        return RedirectToAction("Details", "Products", new { Id = id});
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> RemoveFromCart(string id)
    {
        var user = await this.userManager.GetUserAsync(User);

        var products = user.Basket.Split("; ").Where(p => p != "").ToList();

        products.Remove(id);

        user.Basket = string.Join("; ", products);

        await this.data.SaveChangesAsync();

        return RedirectToAction("Details", "Products", new { Id = id });
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Cart()
    {
        var user = await this.userManager.GetUserAsync(User);

        var products = user.Basket.Split("; ").Where(p => p != "").ToList();

        var model = new ProductsListingModel()
        {
            ListName = "Количка",
            Products = new List<ProductDetailsViewModel>()
        };

        foreach (var product in products)
        {
            model.Products.Add(await this.data.Products
                .Where(p => product != "" && p.Id == int.Parse(product))
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

        return View("All", model);
    }

    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await this.data.Products
            .FirstOrDefaultAsync(r => r.Id == id);

        if (!this.User.IsInRole("Administrator"))
        {
            return BadRequest();
        }

        product.IsDeleted = true;
        
        await this.data.SaveChangesAsync();

        return RedirectToAction("Index", "Home");
    }

    private async Task<List<ProductDetailsViewModel>> GetProducts()
        => await this.data.Products
            .Where(p => p.IsDeleted == false)
            .Select(p => new ProductDetailsViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Category = p.Category,
                CreatedOn = p.CreatedOn,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Color = p.Color,
                Material = p.Material,
                Brand = p.Brand,
                Quantity = p.Quantity,
                Size = p.Size
            })
            .ToListAsync();
}
