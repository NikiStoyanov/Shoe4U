namespace Shoe4U.Controllers;

using Microsoft.AspNetCore.Mvc;

public class ProductsController : Controller
{
	[HttpGet]
	public IActionResult Add() => this.View();

	[HttpGet]
	public IActionResult All() => this.View();

	[HttpGet]
	public IActionResult Details() => this.View();
}
