using CS_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CS_1.Controllers
{
    public class CustomerController : Controller
    {
        private SportsProContext Context { get; set; }

        public CustomerController(SportsProContext ctx) => Context = ctx;

        public IActionResult Index()
        {
            var customer = Context.Customers.OrderBy(p => p.FirstName).ToList();

            return View(customer);
        }

        [HttpGet]

        public IActionResult Add()
        {
            ViewBag.Action = "Add ";
            return View("Edit", new Customer());
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit ";
            var customer = Context.Customers.Find(id);
            return View(customer);
        }

        [HttpPost]

        public IActionResult Edit(Customer modifiedCustomer)
        {
            if (ModelState.IsValid)
            {
                if (modifiedCustomer.CustomerId == 0)
                {
                    Context.Customers.Add(modifiedCustomer);
                }
                else
                {
                    Context.Customers.Update(modifiedCustomer);
                }
                Context.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                ViewBag.Action = (modifiedCustomer.CustomerId == 0) ? "Add " : "Edit ";
                return View(modifiedCustomer);
            }
        }

        [HttpGet]

        public IActionResult Delete(int id)
        {
            ViewBag.Action = "Delete ";
            var customer = Context.Customers.Find(id);

            return View(customer);
        }


        [HttpPost]

        public IActionResult Delete(Customer customer)
        {
            Context.Customers.Remove(customer);
            Context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
    }
}
