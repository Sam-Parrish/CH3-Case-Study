using CS_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CS_1.Controllers
{
    public class CustomerController : Controller
    {
        private SportsProContext Context { get; set; }

        public CustomerController(SportsProContext ctx) => Context = ctx;

        [Route("customers")]
        public IActionResult List()
        {
            var customer = Context.Customers.Include(c => c.Country).OrderBy(p => p.FirstName).ToList();

            return View(customer);
        }

        [HttpGet]

        public IActionResult Add()
        {
            ViewBag.Action = "Add ";
            ViewBag.Countries = Context.Countries.OrderBy(c => c.Name).ToList();
            return View("Edit", new Customer());
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit ";
            ViewBag.Countries = Context.Countries.OrderBy(c => c.Name).ToList();
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
                return RedirectToAction("List", "Customer");
            }
            else
            {
                ViewBag.Action = (modifiedCustomer.CustomerId == 0) ? "Add " : "Edit ";
                ViewBag.Countries = Context.Countries.OrderBy(c => c.Name).ToList();
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
            return RedirectToAction("List", "Customer");
        }
    }
}
