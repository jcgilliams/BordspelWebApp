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
    public class AdminBordspelPersoonController : Controller
    {
        public readonly BordspelWebAppContext _context;
        public AdminBordspelPersoonController(BordspelWebAppContext context)
        {
            _context = context;
        }

        public IActionResult BordspelPersonen()
        {
            ListBordspelPersoonViewModel vm = new ListBordspelPersoonViewModel()
            {
                BordspelPersonen = _context.BordspelPersonen.OrderBy(x => x.Bordspel.Naam).ToList(),
                Bordspellen = _context.Bordspellen.ToList(),
                Personen = _context.Personen.ToList(),
                Rollen = _context.Rollen.ToList(),
            };
            return View(vm);
        }
        public IActionResult CreateBordspelPersoon()
        {
            CreateBordspelPersoonViewModel vm = new CreateBordspelPersoonViewModel()
            {
                Bordspellen = _context.Bordspellen.OrderBy(x => x.Naam).ToList(),
                Personen = _context.Personen.OrderBy(x => x.Naam).ToList(),
                Rollen = _context.Rollen.OrderBy(x => x.Beschrijving).ToList(),
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBordspelPersoonViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new BordspelPersoon()
                {
                    BordspelId = vm.BordspelId,
                    RolId = vm.RolId,
                    PersoonId= vm.PersoonId,
                });

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(BordspelPersonen));
            }
            return View(vm);
        }
        public async Task<IActionResult> DeleteBordspelPersoon(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BordspelPersoon bordspelPersoon = await _context.BordspelPersonen.FirstOrDefaultAsync(p => p.Id == id);
            if (bordspelPersoon == null)
            {
                return NotFound();
            }

            DeleteBordspelPersoonViewModel vm = new DeleteBordspelPersoonViewModel()
            {
                Id = bordspelPersoon.Id,
                BordspelId = bordspelPersoon.BordspelId,
                PersoonId= bordspelPersoon.PersoonId,
                RolId= bordspelPersoon.RolId,
            };
            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            BordspelPersoon bordspelPersoon = await _context.BordspelPersonen.FindAsync(id);
            _context.BordspelPersonen.Remove(bordspelPersoon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(BordspelPersonen));
        }
        public async Task<IActionResult> EditBordspelPersoon(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BordspelPersoon bordspelPersoon = await _context.BordspelPersonen.FindAsync(id);
            if (bordspelPersoon == null)
            {
                return NotFound();
            }

            UpdateBordspelPersoonViewModel vm = new UpdateBordspelPersoonViewModel()
            {
                Id = bordspelPersoon.Id,
                PersoonId = bordspelPersoon.PersoonId,
                BordspelId = bordspelPersoon.BordspelId,
                RolId= bordspelPersoon.RolId,
                Rollen = _context.Rollen.OrderBy(x => x.Beschrijving).ToList(),
                Bordspellen = _context.Bordspellen.OrderBy(x => x.Naam).ToList(),
                Personen = _context.Personen.OrderBy(x => x.Naam).ToList(),
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateBordspelPersoonViewModel vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    BordspelPersoon bordspelPersoon = new BordspelPersoon()
                    {
                        Id = vm.Id,
                        BordspelId = vm.BordspelId,
                        PersoonId= vm.PersoonId,
                        RolId= vm.RolId,
                    };
                    _context.Update(bordspelPersoon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!_context.BordspelPersonen.Any(e => e.Id == vm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(BordspelPersonen));
            }
            return View(vm);
        }
    }
}
