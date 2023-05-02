using CS_1.Models.DataLayer;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CS_1.Models;

namespace CS_1.Controllers
{
    public class HomeController : Controller
    {
		private SportsProContext Context { get; set; }

		public HomeController(SportsProContext ctx) => Context = ctx;

		//[Route("Home")]
		public IActionResult Index()
        {
            ViewBag.SelectedCategoryName = "Home";
            return View();
        }
    }
}