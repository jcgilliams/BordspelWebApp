using BordspelWebApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace BordspelWebApp.Controllers
{
    public class AdminGebruikerController : Controller
    {
        public readonly BordspelWebAppContext _context;
        public AdminGebruikerController(BordspelWebAppContext context)
        {
            _context = context;
        }
        #region Gebruikers
        public IActionResult Gebruikers()
        {
            return View();
        }
        #endregion
    }
}
