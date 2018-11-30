using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GPSTester.App.Models;

namespace GPSTester.App.Controllers
{
    public class HomeController : Controller
    {
        public Location Location { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult Move(LocationModel model, string submitButton)
        {
            if (ModelState.IsValid)
            {
                Location = new Location();
                model.Direction = submitButton;
                Location.Update(model);
            }

            return View("Index", model);
        }
    }
}
