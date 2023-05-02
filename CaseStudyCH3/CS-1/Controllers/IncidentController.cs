using CS_1.Models.DataLayer;
using CS_1.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using CS_1.Models;

namespace CS_1.Controllers
{
    public class IncidentController : Controller
    {
        private SportsProContext Context { get; set; }

        public IncidentController(SportsProContext ctx) => Context = ctx;

        public string sortOption = "All";

        [Route("incidents/{id}")]
        [Route("incidents")]
        public IActionResult List(string id)
        {
            var incident = Context.Incidents.Include(c => c.Customer).Include(p => p.Product).OrderBy(i => i.IncidentId).ToList();

            ViewBag.SelectedCategoryName = "Incident";
            if (id == "1")
            {
                sortOption = "All";
                incident = Context.Incidents.Include(c => c.Customer).Include(p => p.Product).OrderBy(i => i.IncidentId).ToList();
            }
            else if (id == "2")
            {
                sortOption = "Unassign";
                incident = Context.Incidents.Include(c => c.Customer).Include(p => p.Product).Where(t => t.TechnicianId == -1).OrderBy(i => i.IncidentId).ToList();
            }
            else if (id == "3")
            {
                sortOption = "Open";
                incident = Context.Incidents.Include(c => c.Customer).Include(p => p.Product).Where(t => t.DateClosed == null).OrderBy(i => i.IncidentId).ToList();
            }
            else
            {
                sortOption = "All";
                incident = Context.Incidents.Include(c => c.Customer).Include(p => p.Product).OrderBy(i => i.IncidentId).ToList();
            }
            ViewBag.IncidentSort = sortOption;

            return View(incident);
        }

        [HttpGet]

        public IActionResult Add()
        {
            ViewBag.Action = "Add ";
            ViewBag.Customers = Context.Customers.OrderBy(i => i.CustomerId).ToList();
            ViewBag.Products = Context.Products.OrderBy(i => i.ProductId).ToList();
            ViewBag.Technicians = Context.Technicians.OrderBy(i => i.TechnicianId).ToList();
            return View("Edit", new Incident());
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit ";
            ViewBag.Customers = Context.Customers.OrderBy(i => i.CustomerId).ToList();
            ViewBag.Products = Context.Products.OrderBy(i => i.ProductId).ToList();
            ViewBag.Technicians = Context.Technicians.OrderBy(i => i.TechnicianId).ToList();
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
                return RedirectToAction("List", "Incident");
            }
            else
            {
                ViewBag.Action = (modifiedIncident.IncidentId == 0) ? "Add " : "Edit ";
                ViewBag.Customers = Context.Customers.OrderBy(i => i.CustomerId).ToList();
                ViewBag.Products = Context.Products.OrderBy(i => i.ProductId).ToList();
                ViewBag.Technicians = Context.Technicians.OrderBy(i => i.TechnicianId).ToList();
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
            return RedirectToAction("List", "Incident");
        }
    }
}
