using Microsoft.AspNetCore.Mvc;

namespace BordspelWebApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Bordspelbeheer()
        {
            return View();
        }

        public IActionResult Personen()
        {
            return View();
        }

        public IActionResult Uitgeverijen()
        {
            return View();
        }

        public IActionResult Gebruikers()
        {
            return View();
        }
    }
}
