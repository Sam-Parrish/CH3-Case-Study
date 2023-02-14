using CS_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CS_1.Controllers
{
    public class TechnicianController : Controller
    {
        private SportsProContext Context { get; set; }

        public TechnicianController(SportsProContext ctx) => Context = ctx;

        [Route("technicians")]
        public IActionResult List()
        {
            var technician = Context.Technicians.OrderBy(p => p.Name).ToList();

            return View(technician);
        }

        [HttpGet]

        public IActionResult Add()
        {
            ViewBag.Action = "Add ";
            return View("Edit", new Technician());
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit ";
            var technician = Context.Technicians.Find(id);
            return View(technician);
        }

        [HttpPost]

        public IActionResult Edit(Technician modifiedTechnician)
        {
            if (ModelState.IsValid)
            {
                if (modifiedTechnician.TechnicianId == 0)
                {
                    Context.Technicians.Add(modifiedTechnician);
                }
                else
                {
                    Context.Technicians.Update(modifiedTechnician);
                }
                Context.SaveChanges();
                return RedirectToAction("List", "Technician");
            }
            else
            {
                ViewBag.Action = (modifiedTechnician.TechnicianId == 0) ? "Add " : "Edit ";
                return View(modifiedTechnician);
            }
        }

        [HttpGet]

        public IActionResult Delete(int id)
        {
            ViewBag.Action = "Delete ";
            var technician = Context.Technicians.Find(id);

            return View(technician);
        }


        [HttpPost]

        public IActionResult Delete(Technician technician)
        {
            Context.Technicians.Remove(technician);
            Context.SaveChanges();
            return RedirectToAction("List", "Technician");
        }
    }
}
