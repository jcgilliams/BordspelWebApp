using BordspelWebApp.Data;
using BordspelWebApp.Models;
using BordspelWebApp.ViewModels.Create;
using BordspelWebApp.ViewModels.Delete;
using BordspelWebApp.ViewModels.Lists;
using BordspelWebApp.ViewModels.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BordspelWebApp.Controllers
{
    [Authorize]
    public class AdminUitgaveController : Controller
    {
        public readonly BordspelWebAppContext _context;
        public AdminUitgaveController(BordspelWebAppContext context)
        {
            _context = context;
        }

        public IActionResult Uitgaves()
        {
            ListUitgaveBeheerViewModel vm = new ListUitgaveBeheerViewModel()
            {
                Uitgaves = _context.Uitgaven.OrderBy(x => x.Bordspel.Naam).ToList(),
                Uitgeverijen = _context.Uitgeverijen.ToList(),
                Bordspellen = _context.Bordspellen.ToList(),
            };
            return View(vm);
        }

        public IActionResult CreateUitgave()
        {
            CreateUitgaveViewModel vm = new CreateUitgaveViewModel()
            {
                Uitgeverijen = _context.Uitgeverijen.OrderBy(x => x.Naam).ToList(),
                Bordspellen = _context.Bordspellen.OrderBy(x => x.Naam).ToList()
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUitgaveViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Uitgave()
                {
                    BordspelId = vm.BordspelId,
                    UitgeverijId = vm.UitgeverijId,
                    Taal = vm.Taal
                });

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Uitgaves));
            }
            return View(vm);
        }

        public async Task<IActionResult> DeleteUitgave(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Uitgave uitgave = await _context.Uitgaven.FirstOrDefaultAsync(p => p.Id == id);
            if (uitgave == null)
            {
                return NotFound();
            }

            DeleteUitgaveViewModel vm = new DeleteUitgaveViewModel()
            {
                Id = uitgave.Id,
                Taal = uitgave.Taal,
                UitgeverijId = uitgave.UitgeverijId,
                BordspelId = uitgave.BordspelId,
            };
            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Uitgave uitgave = await _context.Uitgaven.FindAsync(id);
            _context.Uitgaven.Remove(uitgave);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Uitgaves));
        }
        public async Task<IActionResult> EditUitgave(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Uitgave uitgave = await _context.Uitgaven.FindAsync(id);
            if (uitgave == null)
            {
                return NotFound();
            }

            UpdateUitgaveViewModel vm = new UpdateUitgaveViewModel()
            {
                Id = uitgave.Id,
                UitgeverijId = uitgave.UitgeverijId,
                BordspelId = uitgave.BordspelId,
                Taal = uitgave.Taal,
                Uitgeverijen = _context.Uitgeverijen.OrderBy(x => x.Naam).ToList(),
                Bordspellen = _context.Bordspellen.OrderBy(x => x.Naam).ToList()
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateUitgaveViewModel vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Uitgave uitgave = new Uitgave()
                    {
                        Id = vm.Id,
                        UitgeverijId = vm.UitgeverijId,
                        BordspelId = vm.BordspelId,
                        Taal = vm.Taal
                    };
                    _context.Update(uitgave);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!_context.Uitgaven.Any(e => e.Id == vm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Uitgaves));
            }
            return View(vm);
        }
    }
}
