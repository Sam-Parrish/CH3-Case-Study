using CS_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CS_1.Controllers
{
    public class TechIncidentController : Controller
    {
        private const string TECH_KEY = "techID";

        private SportsProContext Context { get; set; }

        public TechIncidentController(SportsProContext ctx) => Context = ctx;


        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Technicians = Context.Technicians.Where(t => t.TechnicianId > -1).OrderBy(c => c.Name).ToList();

            var technician = new Technician();

            int? techID = HttpContext.Session.GetInt32(TECH_KEY);
            if (techID.HasValue)
            {
                technician = Context.Technicians.Find(techID);
            }

            return View(technician);
        }

        [HttpPost]
        public IActionResult List(Technician technician)
        {
            if (technician.TechnicianId == 0)
            {
                TempData["message"] = "Please select a technician";
                return RedirectToAction("Index");
            }
            else
            {
                HttpContext.Session.SetInt32(TECH_KEY, technician.TechnicianId);
                return RedirectToAction("List", new {id = technician.TechnicianId});
            }
        }

        [HttpGet]
        public IActionResult List(int id)
        {
            var technician = Context.Technicians.Find(id);
            if(technician == null)
            {
                TempData["message"] = "Technician not found, please select a technician";
                return RedirectToAction("Index");
            }
            else
            {
                var model = new TechIncidentViewModel
                {
                    Technician = technician,
                    Incidents = Context.Incidents.Include(i => i.Customer)
                    .Include(i => i.Product)
                    .OrderBy(i => i.DateOpened)
                    .Where(i => i.TechnicianId == id)
                    .Where(i => i.DateClosed == null)
                    .ToList()
                };
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            int? techID = HttpContext.Session.GetInt32(TECH_KEY);
            if(!techID.HasValue)
            {
                TempData["message"] = "Technician not found, please select a technician";
                return RedirectToAction("Index");
            }
            var technician = Context.Technicians.Find(techID);
            if (technician == null)
            {
                TempData["message"] = "Technician not found, please select a technician";
                return RedirectToAction("Index");
            }
            else
            {
                var model = new TechIncidentViewModel
                {
                    Technician = technician,
                    Incident = Context.Incidents
                    .Include(i => i.Customer)
                    .Include(i => i.Product)
                    .FirstOrDefault(i => i.IncidentId == id)!
                };
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Edit(TechIncidentViewModel model)
        {
            Incident i = Context.Incidents.Find(model.Incident.IncidentId)!;
            i.Description = model.Incident.Description;
            i.DateClosed = model.Incident.DateClosed;

            Context.Incidents.Update(i);
            Context.SaveChanges();

            int? techID = HttpContext.Session.GetInt32(TECH_KEY);
            return RedirectToAction("List", new { id = techID });
        }
    }
}
