using CS_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CS_1.Controllers
{
    public class ProductController : Controller
    {
        private ProductContext context { get; set; }

        public ProductController(ProductContext ctx) => context = ctx;

        public IActionResult Index()
        {
            var product = context.Products.OrderBy(p => p.Name).ToList();

            return View(product);
        }

        [HttpGet]

        public IActionResult Add()
        {
            ViewBag.Action = "Add ";
            return View("Edit", new Product());
        }

        public IActionResult Edit(int code)
        {
            ViewBag.Action = "Edit ";
            var product = context.Products.Find(code);
            return View(product);
        }

        [HttpPost]

        public IActionResult Edit(Product modifiedProduct)
        {
            if (ModelState.IsValid)
            {
                if (modifiedProduct.ProductId == 0)
                {
                    context.Products.Add(modifiedProduct);
                }
                else
                {
                    context.Products.Update(modifiedProduct);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (modifiedProduct.ProductId == 0) ? "Add " : "Edit ";
                return View(modifiedProduct);
            }
        }

        [HttpGet]

        public IActionResult Delete(int code)
        {
            ViewBag.Action = "Delete ";
            var product = context.Products.Find(code);

            return View(product);
        }


        [HttpPost]

        public IActionResult Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
