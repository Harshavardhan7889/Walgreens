using Microsoft.AspNetCore.Mvc;
using Walgreens.Models;

namespace Walgreens.Controllers
{
    public class PrescriptionController : Controller
    {
        private PrescriptionContext context { get; set; }

        public PrescriptionController(PrescriptionContext ctx) => context = ctx;

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            var newPrescription = new Prescription
            {
                RequestTime = DateTime.Now,
                FillStatus = "New"
            };
            return View("Edit", newPrescription);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var prescription = context.Prescription.Find(id);
            return View(prescription);
        }

        [HttpPost]
        public IActionResult Edit(Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                if (prescription.PrescriptionId == 0)
                    context.Prescription.Add(prescription);
                else
                    context.Prescription.Update(prescription);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (prescription.PrescriptionId == 0) ? "Add" : "Edit";
                return View(prescription);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var prescription = context.Prescription.Find(id);
            return View(prescription);
        }

        [HttpPost]
        public IActionResult Delete(Prescription prescription)
        {
            context.Prescription.Remove(prescription);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
