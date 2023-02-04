using CS_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CS_1.Controllers
{
	public class IncidentController : Controller
	{
		private SportsProContext Context { get; set; }

		public IncidentController(SportsProContext ctx) => Context = ctx;

		public IActionResult Index()
		{
            var incident = Context.Incidents.OrderBy(p => p.Customer).ToList();

            return View(incident);
        }

		[HttpGet]

		public IActionResult Add()
		{
			ViewBag.Action = "Add ";
			ViewBag.Incidents = Context.Incidents.OrderBy(i => i.Customer).ToList();
			return View("Edit", new Incident());
		}

		public IActionResult Edit(int id)
		{
			ViewBag.Action = "Edit ";
			ViewBag.Incidents = Context.Incidents.OrderBy(i => i.Customer).ToList();
			var incident = Context.Incidents.Find(id);
			return View(incident);
		}

		[HttpPost]

		public IActionResult Edit(Incident modifiedIncident)
		{
			if (ModelState.IsValid)
			{
				if (modifiedIncident.IncidentId == 0)
				{
					Context.Incidents.Add(modifiedIncident);
				}
				else
				{
					Context.Incidents.Update(modifiedIncident);
				}
				Context.SaveChanges();
				return RedirectToAction("Index", "Incident");
			}
			else
			{
				ViewBag.Action = (modifiedIncident.IncidentId == 0) ? "Add " : "Edit ";
				ViewBag.Incidents = Context.Incidents.OrderBy(i => i.Customer).ToList();
				return View(modifiedIncident);
			}
		}

		[HttpGet]

		public IActionResult Delete(int id)
		{
			ViewBag.Action = "Delete ";
			var incident = Context.Incidents.Find(id);

			return View(incident);
		}


		[HttpPost]

		public IActionResult Delete(Incident incident)
		{
			Context.Incidents.Remove(incident);
			Context.SaveChanges();
			return RedirectToAction("Index", "Incident");
		}
	}
}
