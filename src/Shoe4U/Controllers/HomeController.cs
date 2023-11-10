namespace Shoe4U.Controllers;

using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index() => this.View();

    [HttpGet]
    public IActionResult Privacy() => this.View();
}