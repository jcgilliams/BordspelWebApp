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
    public class AdminPersoonController : Controller
    {
        public readonly BordspelWebAppContext _context;
        public AdminPersoonController(BordspelWebAppContext context)
        {
            _context = context;
        }
        #region Personen
        public IActionResult Personen()
        {
            ListPersonenBeheerViewModel vm = new ListPersonenBeheerViewModel()
            {
                Personen = _context.Personen.OrderBy(x => x.Naam).ToList()
            };
            return View(vm);
        }

        public IActionResult CreatePersoon()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePersoonViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Persoon()
                {
                    Voornaam = vm.Voornaam,
                    Naam = vm.Naam,
                    Beschrijving = vm.Beschrijving,
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Personen));
            }
            return View(vm);
        }

        public async Task<IActionResult> DeletePersoon(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Persoon persoon = await _context.Personen.FirstOrDefaultAsync(p => p.Id == id);
            if (persoon == null)
            {
                return NotFound();
            }

            DeletePersoonViewModel vm = new DeletePersoonViewModel()
            {
                Id = persoon.Id,
                Voornaam = persoon.Voornaam,
                Naam = persoon.Naam,
                Beschrijving = persoon.Beschrijving,
            };
            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Persoon persoon = await _context.Personen.FindAsync(id);
            _context.Personen.Remove(persoon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Personen));
        }

        public async Task<IActionResult> EditPersoon(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Persoon persoon = await _context.Personen.FindAsync(id);
            if (persoon == null)
            {
                return NotFound();
            }

            UpdatePersoonViewModel vm = new UpdatePersoonViewModel()
            {
                Id = persoon.Id,
                Voornaam = persoon.Voornaam,
                Naam = persoon.Naam,
                Beschrijving = persoon.Beschrijving
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdatePersoonViewModel vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Persoon persoon = new Persoon()
                    {
                        Id = vm.Id,
                        Voornaam = vm.Voornaam,
                        Naam = vm.Naam,
                        Beschrijving = vm.Beschrijving
                    };
                    _context.Update(persoon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!_context.Personen.Any(e => e.Id == vm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Personen));
            }
            return View(vm);
        }

        #endregion
    }
}
