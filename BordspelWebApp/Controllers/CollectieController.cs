using BordspelWebApp.Areas.Data;
using BordspelWebApp.Data;
using BordspelWebApp.Models;
using BordspelWebApp.ViewModels.Create;
using BordspelWebApp.ViewModels.Delete;
using BordspelWebApp.ViewModels.Lists;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BordspelWebApp.Controllers
{
    public class CollectieController : Controller
    {
        public readonly BordspelWebAppContext _context;
        private UserManager<Gebruiker> _userManager;
        public CollectieController(BordspelWebAppContext context, UserManager<Gebruiker> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            CreateCollectionViewModel vm = new CreateCollectionViewModel()
            {
                Collecties = _context.Collecties.OrderBy(x => x.Bordspel.Naam).ToList(),
                Bordspellen = _context.Bordspellen.ToList(),
                Gebruikers = _userManager.Users.ToList()
            };
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult>Create(int id)
        {
            Gebruiker user = await _userManager.GetUserAsync(HttpContext.User);

                _context.Add(new Collectie()
                {
                    BordspelId = id,
                    GebruikersId = user.Id,
                });

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteBordspelUitCollectie(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Collectie collectieItem = await _context.Collecties.FirstOrDefaultAsync(p => p.Id == id);
            if (collectieItem == null)
            {
                return NotFound();
            }

            DeleteBordspelUitCollectieModelView vm = new DeleteBordspelUitCollectieModelView()
            {
                Id = collectieItem.Id,
                BordspelId = collectieItem.BordspelId,
                GebruikerId = collectieItem.GebruikersId
            };
            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Collectie collectieItem = await _context.Collecties.FindAsync(id);
            _context.Collecties.Remove(collectieItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
