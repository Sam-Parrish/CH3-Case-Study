using CS_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CS_1.Controllers
{
	public class ProductsController : Controller
	{
		private ProductsContext context { get; set; }

		public ProductsController(ProductsContext ctx) => context = ctx;

		[HttpGet]

		public IActionResult Add()
		{
			ViewBag.Action = "Add";
			return View("Edit", new Products());
		}

		public IActionResult Edit(int code)
		{
			ViewBag.Action = "Edit";
			var product = context.Products.Find(code);
			return View(product);
		}

		public IActionResult Index()
		{
			var products = context.Products.OrderBy(p => p.Name).ToList();

			return View(products);
		}
	}
}
