using BordspelWebApp.Areas.Data;
using BordspelWebApp.Data;
using BordspelWebApp.Models;
using BordspelWebApp.ViewModels;
using BordspelWebApp.ViewModels.Delete;
using BordspelWebApp.ViewModels.Details;
using BordspelWebApp.ViewModels.Lists;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System;
using BordspelWebApp.Data.UnitOfWork;
using System.Data;

namespace BordspelWebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminGebruikerController : Controller
    {
        private UserManager<Gebruiker> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public AdminGebruikerController(UserManager<Gebruiker> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        #region Gebruikers
        public IActionResult Gebruikers()
        {
            ListGebruikersViewModel viewModel = new ListGebruikersViewModel()
            {
                Gebruikers = _userManager.Users.ToList()
            };
            return View(viewModel);
        }
        public IActionResult DetailsGebruiker(string id)
        {
            Gebruiker gebruiker = _userManager.Users.Where(g =>g.Id == id).FirstOrDefault();

            if (gebruiker != null)
            {
                DetailsGebruikerViewModel viewModel = new DetailsGebruikerViewModel()
                {
                    Id = gebruiker.Id,
                    Naam = gebruiker.Naam,
                    Voornaam = gebruiker.Voornaam,
                    UserName = gebruiker.UserName,
                };
                return View(viewModel);
            }
            else
            {
                DetailsGebruikerViewModel viewModel = new DetailsGebruikerViewModel()
                {
                    Gebruikers = _userManager.Users.ToList(),
                };
                return View("Gebruikers",viewModel);
            }
        }
        public async Task<IActionResult> DeleteGebruiker(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Gebruiker gebruiker = await _userManager.FindByIdAsync(id);
            if (gebruiker == null)
            {
                return NotFound();
            }

            DeleteGebruikerViewModel vm = new DeleteGebruikerViewModel()
            {
                Id = gebruiker.Id,
                Voornaam = gebruiker.Voornaam,
                Naam = gebruiker.Naam,
                UserName = gebruiker.UserName,
            };
            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            Gebruiker gebruiker = await _userManager.FindByIdAsync(id);
            if (gebruiker != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(gebruiker);
                if (result.Succeeded)
                    return RedirectToAction("Gebruikers");
                else
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
            }
            else
                ModelState.AddModelError("", "User not found");
            return View("Gebruikers", _userManager.Users.ToList());
        }
        #endregion
        #region GrantPermission
        public IActionResult GrantPermissions()
        {
            GrantPermissionsViewModel viewModel = new GrantPermissionsViewModel()
            {
                Gebruikers = new SelectList(_userManager.Users.ToList(), "Id", "UserName"),
                Rollen = new SelectList(_roleManager.Roles.ToList(), "Id", "Name"),
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> GrantPermissions(GrantPermissionsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Gebruiker user = await _userManager.FindByIdAsync(viewModel.GebruikerId);
                IdentityRole role = await _roleManager.FindByIdAsync(viewModel.RolId);

                if (!await _userManager.IsInRoleAsync(user, role.Name))
                {
                    if (user != null && role != null)
                    {
                        IdentityResult result = await _userManager.AddToRoleAsync(user, role.Name);

                        if (result.Succeeded)
                            return RedirectToAction(nameof(Gebruikers));
                        else
                        {
                            foreach (IdentityError error in result.Errors)
                                ModelState.AddModelError("", error.Description);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "User or role Not found");
                    }
                }
                else
                {
                    return RedirectToAction(nameof(Gebruikers));
                }
            }
            return View(viewModel);
        }
        #endregion
    }
}
