using BordspelWebApp.Models;
using BordspelWebApp.ViewModels.Lists;
using BordspelWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BordspelWebApp.Data;
using BordspelWebApp.ViewModels.Details;
using Microsoft.EntityFrameworkCore;
using BordspelWebApp.Areas.Data;
using Microsoft.AspNetCore.Identity;

namespace BordspelWebApp.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public readonly BordspelWebAppContext _context;
        private UserManager<Gebruiker> _userManager;
        public HomeController(BordspelWebAppContext context, UserManager<Gebruiker> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ListBordspelViewModel vm = new ListBordspelViewModel()
            {
                Bordspellen = _context.Bordspellen.OrderBy(x=>x.Naam).ToList(),
                Collectie = _context.Collecties.ToList() //  hier where met id gebruiker + in if statement contains bordspel zit in lijst
            };
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult OverOns()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult DetailsBordspel(int id)
        {
            Bordspel bordspel = _context.Bordspellen.Where(b => b.Id == id)
                .FirstOrDefault();

            ICollection<BordspelPersoon> BordspelPersonen = _context.BordspelPersonen.Where(b => b.BordspelId == id)
                .Include(p=>p.Persoon)
                .Include(r=>r.Rol)
                .ToList();

            ICollection<Uitgave> Uitgaven = _context.Uitgaven.Where(b => b.BordspelId == id)
                .Include(u => u.Uitgeverij)
                .ToList();

            if (bordspel != null)
            {
                DetailsBordspelViewModel vm = new DetailsBordspelViewModel()
                {
                    Id = bordspel.Id,
                    Naam = bordspel.Naam,
                    Jaar = bordspel.Jaar,
                    Beschrijving = bordspel.Beschrijving,
                    MinAantalSpelers = bordspel.MinAantalSpelers,
                    MaxAantalSpelers = bordspel.MaxAantalSpelers,
                    MinSpeeltijd = bordspel.MinSpeeltijd,
                    MaxSpeeltijd = bordspel.MaxSpeeltijd,
                    Leeftijd = bordspel.Leeftijd,
                    Afbeelding = bordspel.Afbeelding,
                    BordspelPersonen = BordspelPersonen,
                    Uitgaves = Uitgaven
                };

                return View(vm);
            }
            else
            {
                ListBordspelViewModel vm = new ListBordspelViewModel()
                {
                    Bordspellen = _context.Bordspellen.OrderBy(x => x.Naam).ToList()
                };
                return View("Index", vm);
            }
        }
        public IActionResult Search(ListBordspelViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(viewModel.SpelZoeken))
            {
                viewModel.Bordspellen = _context.Bordspellen.Where(p => p.Naam.Contains(viewModel.SpelZoeken)).ToList();
            }
            else
            {
                viewModel.Bordspellen = _context.Bordspellen.ToList();
            }

            return View("Index", viewModel);
        }
    }
}
