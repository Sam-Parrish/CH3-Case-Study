using CS_1.Models.DataLayer;
using CS_1.Models.DomainModels;
using CS_1.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CS_1.Models;

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
            var customer = Context.Customers.Include(c => c.Products).Where(c => c.CustomerId == id).FirstOrDefault();

            if (customer == null)
            {
                TempData["message"] = "Customer not found, please select a customer";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Products = Context.Products.OrderBy(c => c.ProductId).ToList();

                var model = new RegistrationViewModel
                {
                    Customer = customer,
                    //Products = Context.Customers.Include(c => c.Products).Where
                    
                    //Products
                    //.Include(t => t.Customers.Where(q => q.CustomerId == id))
                    //.OrderBy(i => i.ProductId)
                    //.ToList()
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
            var customer = Context.Customers.Include(c => c.Products).Where(c => c.CustomerId == custId).FirstOrDefault();

            var vm = new RegistrationViewModel();

            if (customer != null && productFind != null)
            {
                if (prodId == 0)
                {
                    TempData["message"] = "Please select a product.";
                    return RedirectToAction("List", new { id = custId });
                }
                else
                {
                    if (customer.Products.Any(p => p.ProductId == prodId))
                    {
                        TempData["message"] = "Product already registered";
                    }
                    else
                    {
                        TempData["message"] = "Customer registered";
                        customer.Products.Add(productFind);
                        vm.Customer = customer;
                        vm.Products = Context.Products.ToList();
                        Context.SaveChanges();
                    }
                }
            }
            return RedirectToAction("List", new { id = custId });
        }
    }
}
