using CS_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CS_1.Controllers
{
    public class RegistrationController : Controller
    {
        private const string REGISTRATION_KEY = "techID";

        private SportsProContext Context { get; set; }

        public RegistrationController(SportsProContext ctx) => Context = ctx;

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.SelectedCategoryName = "Register";
            ViewBag.Customers = Context.Customers.OrderBy(c => c.FirstName).ToList();

            var customer = new Customer();

            int? custID = HttpContext.Session.GetInt32(REGISTRATION_KEY);
            if (custID.HasValue)
            {
                customer = Context.Customers.Find(custID);
            }

            return View(customer);
        }

        [HttpPost]
        public IActionResult List(Customer customer)
        {
            if (customer.CustomerId == 0)
            {
                TempData["message"] = "Please select a customer";
                return RedirectToAction("Index");
            }
            else
            {
                HttpContext.Session.SetInt32(REGISTRATION_KEY, customer.CustomerId);
                return RedirectToAction("List");
            }
        }

        [HttpGet]
        public IActionResult List()
        {
            int? id = HttpContext.Session.GetInt32(REGISTRATION_KEY);
            var customer = Context.Customers.Find(id);
            if (customer == null)
            {
                TempData["message"] = "Customer not found, please select a customer";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Products = Context.Products.OrderBy(c => c.Name).ToList();

                var model = new RegistrationViewModel
                {
                    Customer = customer,
                    Products = Context.Products
                    .Where(r => r.Registered == customer.FullName)
                    .OrderBy(i => i.Name)
                    .ToList()
                };
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Register(Product product)
        {
            var prodId = product.ProductId;
            var productFind = Context.Products.Find(prodId);

            int? custId = HttpContext.Session.GetInt32(REGISTRATION_KEY);
            var customer = Context.Customers.Find(custId);

            if(customer != null && productFind != null)
            {
                if(productFind.Registered == customer.FullName)
                {
                    TempData["message"] = $"{customer.FullName} is already registered to this product";
                    return RedirectToAction("List", "Registration");
                }
                else
                {
                    productFind.Registered = customer.FullName;
                    Context.Products.Update(productFind);
                }
            }
            else
            {
                return RedirectToAction("List", "Registration");
            }
            Context.SaveChanges();
            return RedirectToAction("List", "Registration");
        }
    }
}
