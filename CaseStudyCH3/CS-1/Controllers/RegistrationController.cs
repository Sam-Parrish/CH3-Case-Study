using CS_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace CS_1.Controllers
{
    public class RegistrationController : Controller
    {
        private const string TECH_KEY = "techID";

        private SportsProContext Context { get; set; }

        public RegistrationController(SportsProContext ctx) => Context = ctx;

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.SelectedCategoryName = "Register";
            ViewBag.Customers = Context.Customers.OrderBy(c => c.FirstName).ToList();

            var customer = new Customer();

            int? custID = HttpContext.Session.GetInt32(TECH_KEY);
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
                HttpContext.Session.SetInt32(TECH_KEY, customer.CustomerId);
                return RedirectToAction("List", new { id = customer.CustomerId });
            }
        }
    }
}
