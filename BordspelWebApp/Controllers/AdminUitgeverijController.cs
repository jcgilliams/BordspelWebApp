using BordspelWebApp.Data;
using BordspelWebApp.Models;
using BordspelWebApp.ViewModels.Create;
using BordspelWebApp.ViewModels.Delete;
using BordspelWebApp.ViewModels.Lists;
using BordspelWebApp.ViewModels.Update;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BordspelWebApp.Controllers
{
    public class AdminUitgeverijController : Controller
    {
        public readonly BordspelWebAppContext _context;
        public AdminUitgeverijController(BordspelWebAppContext context)
        {
            _context = context;
        }
        #region Uitgeverijen
        public IActionResult Uitgeverijen()
        {
            ListUitgeverijenBeheerViewModel vm = new ListUitgeverijenBeheerViewModel()
            {
                Uitgeverijen = _context.Uitgeverijen.OrderBy(x => x.Naam).ToList()
            };
            return View(vm);
        }
        public IActionResult CreateUitgeverij()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUitgeverijViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Uitgeverij()
                {
                    Naam = vm.Naam,
                    Beschrijving = vm.Beschrijving,
                    Land = vm.Land,
                    Website = vm.Website,
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Uitgeverijen));
            }
            return View(vm);
        }
        public async Task<IActionResult> DeleteUitgeverij(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Uitgeverij uitgeverij = await _context.Uitgeverijen.FirstOrDefaultAsync(p => p.Id == id);
            if (uitgeverij == null)
            {
                return NotFound();
            }

            DeleteUitgeverijViewModel vm = new DeleteUitgeverijViewModel()
            {
                Id = uitgeverij.Id,
                Naam = uitgeverij.Naam,
                Beschrijving = uitgeverij.Beschrijving,
                Land = uitgeverij.Land,
                Website = uitgeverij.Website,
            };
            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Uitgeverij uitgeverij = await _context.Uitgeverijen.FindAsync(id);
            _context.Uitgeverijen.Remove(uitgeverij);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Uitgeverijen));
        }

        public async Task<IActionResult> EditUitgeverij(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Uitgeverij uitgeverij = await _context.Uitgeverijen.FindAsync(id);
            if (uitgeverij == null)
            {
                return NotFound();
            }

            UpdateUitgeverijViewModel vm = new UpdateUitgeverijViewModel()
            {
                Id = uitgeverij.Id,
                Naam = uitgeverij.Naam,
                Beschrijving = uitgeverij.Beschrijving,
                Land = uitgeverij.Land,
                Website = uitgeverij.Website,
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateUitgeverijViewModel vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Uitgeverij uitgeverij = new Uitgeverij()
                    {
                        Id = vm.Id,
                        Naam = vm.Naam,
                        Beschrijving = vm.Beschrijving,
                        Land = vm.Land,
                        Website= vm.Website,
                    };
                    _context.Update(uitgeverij);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!_context.Uitgeverijen.Any(e => e.Id == vm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Uitgeverijen));
            }
            return View(vm);
        }

        #endregion
    }
}
