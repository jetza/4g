using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oprema_za_mob_telefone.Data;
using Oprema_za_mob_telefone.Models;
using Oprema_za_mob_telefone.Models.HomeViewModels;
using Microsoft.EntityFrameworkCore;

namespace Oprema_za_mob_telefone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext; // Neka izmjena 1
            // Neka izmjena 23
        }
        public IActionResult Index()
        {
            var proizvodi = this.dbContext.Proizvodi.Include(x => x.Kategorija).ToList(); //ucitava sve proizvode iz baze

            var model = proizvodi.Select(proizvod => new ProizvodViewModel
            {
                Id = proizvod.Id,
                Naziv = proizvod.Naziv,
                NazivKategorije = proizvod.Kategorija.Naziv,
                Cena = proizvod.Cena,
                Opis = proizvod.Opis,
                Slika = proizvod.Slika
            }).ToArray();


            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = " ";

            return View();
        }

        public IActionResult Novosti()
        {
            ViewData["Message"] = " ";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = " ";

            return View();
        }
        public IActionResult Korpa()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
