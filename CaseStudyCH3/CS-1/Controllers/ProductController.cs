using CS_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CS_1.Controllers
{
    public class ProductController : Controller
    {
        private SportsProContext Context { get; set; }

        public ProductController(SportsProContext ctx) => Context = ctx;

        public string sortOrder = "High";

		[Route("products")]
		public IActionResult List(string id)
        {
			ViewBag.SelectedCategoryName = "Product";
			var product = Context.Products.OrderByDescending(p => p.Price).ToList();
            if (id == "1")
            {
                product = Context.Products.OrderByDescending(p => p.Price).ToList();
                ViewBag.ProductSort = "High";
                sortOrder = "High";
            }
            else if (id == "2")
            {
                product = Context.Products.OrderBy(p => p.Price).ToList();
                ViewBag.ProductSort = "Low";
                sortOrder = "Low";
            }
            else
            {
                product = Context.Products.OrderByDescending(p => p.Price).ToList();
                ViewBag.ProductSort = "High";
                sortOrder = "High";
            }

            return View(product);
        }

        [HttpGet]

        public IActionResult Add()
        {
            ViewBag.Action = "Add ";
            return View("Edit", new ConfigureProducts());
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit ";
            var product = Context.Products.Find(id);
            return View(product);
        }

        [HttpPost]

        public IActionResult Edit(Product modifiedProduct)
        {
            if (ModelState.IsValid)
            {
                if (modifiedProduct.ProductId == 0)
                {
                    Context.Products.Add(modifiedProduct);
                    TempData["message"] = $"{modifiedProduct.Name} was successfully added";
                }
                else
                {
                    Context.Products.Update(modifiedProduct);
					TempData["message"] = $"{modifiedProduct.Name} was successfully changed";
				}
                Context.SaveChanges();
                return RedirectToAction("List", "Product");
            }
            else
            {
                ViewBag.Action = (modifiedProduct.ProductId == 0) ? "Add " : "Edit ";
                return View(modifiedProduct);
            }
         }

        [HttpGet]

        public IActionResult Delete(int id)
        {
            ViewBag.Action = "Delete ";
            var product = Context.Products.Find(id);

            return View(product);
        }


        [HttpPost]

        public IActionResult Delete(Product product)
        {
            TempData["message"] = $"Product was successfully deleted";
            Context.Products.Remove(product);
            Context.SaveChanges();
            return RedirectToAction("List", "Product");
        }
    }
}
