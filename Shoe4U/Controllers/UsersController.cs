namespace Shoe4U.Controllers;

using Data;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Users;
using System.Security.Claims;

public class UsersController : Controller
{
	private readonly UserManager<User> userManager;
	private readonly Shoe4UDbContext data;

	public UsersController(UserManager<User> userManager, Shoe4UDbContext data)
	{
		this.userManager = userManager;
		this.data = data;
	}

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Details()
    {
	    var user = await this.userManager.GetUserAsync(User);

	    var model = new UserDetailsViewModel()
	    {
		    Email = user.Email,
		    Id = user.Id,
		    Name = user.Name,
	    };

	    return this.View(model);
    }

    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public IActionResult All()
    {
        var users = this.data.Users
            .Select(u => new UserDetailsViewModel()
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            })
            .ToList();

        return View(users);
    }

    [HttpGet]
    [Authorize]
    public IActionResult Edit(string id)
    {
        if (!this.User.IsInRole("Administrator") || id == null)
        {
            id = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        var user = this.data.Users
            .Where(u => u.Id == id)
            .Select(u => new UserDetailsViewModel()
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            })
            .Single();

        return View(user);
    }

    [HttpPost]
    [Authorize]
    public IActionResult Update(string id, UserInputModel input)
    {
        if (!this.User.IsInRole("Administrator"))
        {
            id = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        var user = this.data.Users
            .FirstOrDefault(u => u.Id == id);

        user.Name = input.Name;
        user.Email = input.Email;
        user.NormalizedEmail = input.Email.ToUpper();
        user.UserName = input.Email;
        user.UserName = input.Email.ToUpper();

        this.data.SaveChanges();

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public IActionResult Delete(string id)
    {
        foreach (var review in this.data.Reviews.Where(r => r.UserId == id))
        {
            this.data.Reviews.Remove(review);
        }

        foreach (var order in this.data.Orders.Where(o => o.UserId == id))
        {
            foreach (var orderProduct in this.data.OrderProducts.Where(op => op.OrderId == order.Id))
            {
                this.data.OrderProducts.Remove(orderProduct);
            }

            this.data.Orders.Remove(order);
        }

        var user = this.data.Users
            .FirstOrDefault(u => u.Id == id);

        this.data.Users.Remove(user);
        this.data.SaveChanges();

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public IActionResult Add()
        => View();

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Create(UserInputModel input)
    {
        var user = new User
        {
            UserName = input.Email,
            Email = input.Email,
            Name = input.Name
        };

        await userManager.CreateAsync(user, input.Password);

        return RedirectToAction("All");
    }
}