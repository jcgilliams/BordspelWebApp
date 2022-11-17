using Microsoft.AspNetCore.Mvc;

namespace BordspelWebApp.Controllers
{
    public class CollectieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
