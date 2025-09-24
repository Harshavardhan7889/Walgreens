using Microsoft.AspNetCore.Mvc;

using Walgreens.Models;

namespace MovieList.Controllers
{
    public class HomeController : Controller
    {
        private PrescriptionContext context { get; set; }

        public HomeController(PrescriptionContext ctx) => context = ctx;

        public IActionResult Index()
        {
            var prescriptions = context.Prescription.OrderBy(m => m.MedicationName).ToList();
            return View(prescriptions);
        }
    }
}