namespace Shoe4U.Controllers;

using Microsoft.AspNetCore.Mvc;

public class OrdersController : Controller
{
	[HttpGet]
	public IActionResult Cart() => this.View();

	[HttpGet]
	public IActionResult Checkout() => this.View();

	[HttpGet]
	public IActionResult Confirmation() => this.View();
}
