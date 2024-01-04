namespace Shoe4U.Controllers;

using Data;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Products;

public class ProductsController : Controller
{
    private readonly Shoe4UDbContext db;

    public ProductsController(Shoe4UDbContext db)
    {
        this.db = db;
    }
	[HttpGet]
	[Authorize(Roles = "Administrator")]
	public IActionResult Add() => this.View();

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Create(CreateProductInputModel model)
    {
        model.Image = this.Request.Form.Files["image"];

        var fileName = Path.GetFileName(model.Image.FileName);
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", fileName);

        using var fileStream = new FileStream(filePath, FileMode.Create);

        await model.Image.CopyToAsync(fileStream);

        fileStream.Close();

        var product = new Product
        {
            Name = model.Name,
            Description = model.Description,
            Availability = model.Availability,
            Price = model.Price,
            Color = model.Color,
            Brand = model.Brand,
            Material = model.Material,
            Size = model.Size,
            ImageUrl = filePath
        };

        await this.db.Products.AddAsync(product);

        await this.db.SaveChangesAsync();

        return RedirectToAction("Add");
    }

	[HttpGet]
	public IActionResult All() => this.View();

	[HttpGet]
	public IActionResult Details() => this.View();
}
