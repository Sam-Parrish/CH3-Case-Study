using CS_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CS_1.Controllers
{
    public class ProductController : Controller
    {
        private SportsProContext Context { get; set; }

        public ProductController(SportsProContext ctx) => Context = ctx;

		[Route("products")]
		public IActionResult List()
        {
			ViewBag.SelectedCategoryName = "Product";
			var product = Context.Products.OrderBy(p => p.Name).ToList();

            return View(product);
        }

        [HttpGet]

        public IActionResult Add()
        {
            ViewBag.Action = "Add ";
            return View("Edit", new Product());
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
                }
                else
                {
                    Context.Products.Update(modifiedProduct);
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
            Context.Products.Remove(product);
            Context.SaveChanges();
            return RedirectToAction("List", "Product");
        }
    }
}
