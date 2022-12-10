using BordspelWebApp.Data;
using BordspelWebApp.Models;
using BordspelWebApp.ViewModels.Create;
using BordspelWebApp.ViewModels.Delete;
using BordspelWebApp.ViewModels.Lists;
using BordspelWebApp.ViewModels.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace BordspelWebApp.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public readonly BordspelWebAppContext _context;
        public AdminController(BordspelWebAppContext context)
        {
            _context = context;
        }
        #region Bordspellen
        public IActionResult Bordspelbeheer()
        {
            ListBordspelBeheerViewModel vm = new ListBordspelBeheerViewModel()
            {
                Bordspellen = _context.Bordspellen.OrderBy(x => x.Naam).ToList()
            };
            return View(vm);
        }
        public IActionResult CreateBordspel()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBordspelViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Bordspel()
                {
                    Naam = vm.Naam,
                    Beschrijving = vm.Beschrijving,
                    Jaar = vm.Jaar,
                    MinAantalSpelers = vm.MinAantalSpelers,
                    MaxAantalSpelers = vm.MaxAantalSpelers,
                    MinSpeeltijd = vm.MinSpeeltijd,
                    MaxSpeeltijd = vm.MaxSpeeltijd,
                    Leeftijd = vm.Leeftijd,
                    Afbeelding = "dummy.jpg",                   
                });

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Bordspelbeheer));
            }
            return View(vm);
        }
        public async Task<IActionResult> DeleteBordspel(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bordspel bordspel = await _context.Bordspellen.FirstOrDefaultAsync(p => p.Id == id);
            if (bordspel == null)
            {
                return NotFound();
            }

            DeleteBordspelViewModel vm = new DeleteBordspelViewModel()
            {
                Id = bordspel.Id,
                Naam = bordspel.Naam,
                Beschrijving = bordspel.Beschrijving,
                Jaar = bordspel.Jaar,
                MinAantalSpelers = bordspel.MinAantalSpelers,
                MaxAantalSpelers = bordspel.MaxAantalSpelers,
                MinSpeeltijd = bordspel.MinSpeeltijd,
                MaxSpeeltijd = bordspel.MaxSpeeltijd,
                Leeftijd = bordspel.Leeftijd,
                Afbeelding = bordspel.Afbeelding,
            };
            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Bordspel bordspel = await _context.Bordspellen.FindAsync(id);
            _context.Bordspellen.Remove(bordspel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Bordspelbeheer));
        }
        public async Task<IActionResult> EditBordspel(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bordspel bordspel = await _context.Bordspellen.FindAsync(id);
            if (bordspel == null)
            {
                return NotFound();
            }

            UpdateBordspelViewModel vm = new UpdateBordspelViewModel()
            {
                Id = bordspel.Id,
                Naam = bordspel.Naam,
                Beschrijving = bordspel.Beschrijving,
                Jaar = bordspel.Jaar,
                MinAantalSpelers = bordspel.MinAantalSpelers,
                MaxAantalSpelers = bordspel.MaxAantalSpelers,
                MinSpeeltijd = bordspel.MinSpeeltijd,
                MaxSpeeltijd = bordspel.MaxSpeeltijd,
                Leeftijd = bordspel.Leeftijd,
                Afbeelding = bordspel.Afbeelding,
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateBordspelViewModel vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Bordspel bordspel = new Bordspel()
                    {
                        Id = vm.Id,
                        Naam = vm.Naam,
                        Beschrijving = vm.Beschrijving,
                        Jaar = vm.Jaar,
                        MinAantalSpelers = vm.MinAantalSpelers,
                        MaxAantalSpelers = vm.MaxAantalSpelers,
                        MinSpeeltijd = vm.MinSpeeltijd,
                        MaxSpeeltijd = vm.MaxSpeeltijd,
                        Leeftijd = vm.Leeftijd,
                        Afbeelding = vm.Afbeelding,
                    };
                    _context.Update(bordspel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!_context.Bordspellen.Any(e => e.Id == vm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Bordspelbeheer));
            }
            return View(vm);
        }

        #endregion
    }
}
