namespace Shoe4U.Controllers;

using Data;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Messages;
using ViewModels.Products;

public class HomeController : Controller
{
    private readonly Shoe4UDbContext db;
    private readonly UserManager<User> userManager;

    public HomeController(Shoe4UDbContext db, UserManager<User> userManager)
    {
	    this.db = db;
	    this.userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var products = await this.db.Products
            .Where(p => p.IsDeleted == false)
            .OrderByDescending(p => p.CreatedOn)
            .Take(3)
            .Select(product => new LastThreeProductsViewModel() 
            {
                Id = product.Id,
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
            })
            .ToListAsync();

        return this.View(products);
    }

    [HttpGet]
    public async Task<IActionResult> Contacts()
    {
	    var user = await this.userManager.GetUserAsync(User);

	    var model = new CreateMessageInputModel();

	    if (user != null)
	    {
		    model.Name = user.Name;
		    model.Email = user.Email;
	    }

	    return this.View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Message(CreateMessageInputModel model)
    {
	    var message = new Message()
	    {
		    Name = model.Name,
		    Email = model.Email,
		    Subject = model.Subject,
		    Content = model.Content
	    };

	    await this.db.Messages.AddAsync(message);

	    await this.db.SaveChangesAsync();

	    return this.RedirectToAction("Contacts");
    }

    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Messages()
    {
        var messages = await this.db.Messages
            .Select(message => new MessageDetailsViewModel()
            {
                Id = message.Id,
                Name = message.Name,
                Email = message.Email,
                Subject = message.Subject,
                Content = message.Content
            })
            .ToListAsync();

        return this.View(messages);
    }
}