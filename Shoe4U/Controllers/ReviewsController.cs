namespace Shoe4U.Controllers;

using Data.Models;
using Microsoft.AspNetCore.Identity;
using Models.Reviews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Data;


public class ReviewsController : Controller
{
    private readonly Shoe4UDbContext db;
    private readonly UserManager<User> userManager;

    public ReviewsController(Shoe4UDbContext db, UserManager<User> userManager)
    {
        this.db = db;
        this.userManager = userManager;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(CreateReviewInputModel model)
    {
        var user = await this.userManager.GetUserAsync(User);

        var review = new Review()
        {
            Content = model.Content,
            ProductId = model.ProductId,
            UserId = user.Id
        };

        await this.db.Reviews.AddAsync(review);
        await this.db.SaveChangesAsync();

        return RedirectToAction("Details", "Products", new { id = model.ProductId });
    }
}
