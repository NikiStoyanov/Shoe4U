namespace Shoe4U.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class ProfileController : Controller
{
    [HttpGet]
    [Authorize]
    public IActionResult Dashboard() => this.View();

    [HttpGet]
    [Authorize]
    public IActionResult Details() => this.View();

    [HttpGet]
    [Authorize]
    public IActionResult Orders() => this.View();
}