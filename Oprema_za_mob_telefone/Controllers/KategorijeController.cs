using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oprema_za_mob_telefone.Data;
using Oprema_za_mob_telefone.Models.KategorijeViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Oprema_za_mob_telefone.Controllers
{
    [Authorize(Roles ="Admin")]//sakriva kategorije za sve osim admina
    public class KategorijeController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public KategorijeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }

        public IActionResult Index()
        {
            var kategorije = this.dbContext.Kategorije.ToList(); //ucitava sve kategorije iz baze

            var model = kategorije.Select(kategorija => new KategorijaViewModel
            {
                Id = kategorija.Id,
                Naziv = kategorija.Naziv
            });

            return View(model);
        }

        [HttpGet]
        public IActionResult Kreiraj()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Kreiraj(KreirajKategorijuViewModel model)
        {
            if (!ModelState.IsValid) //proverava da li je ime i uneseno kako treba
            {
                return View(model);
            }

            var kategorija = new Kategorija { Naziv = model.Naziv };
            this.dbContext.Kategorije.Add(kategorija); //ubacuje u bazu

            this.dbContext.SaveChanges(); //prihvatamo izmene u dbcontextu

            return RedirectToAction("Index");
        }

        public IActionResult Izmeni(int id)
        {
            var kategorija = this.dbContext.Kategorije.Find(id);
            if (kategorija == null)
            {
                return NotFound(); //404
            }

            var model = new IzmeniKategorijuViewModel //pretvara u view model
            {
                Id = kategorija.Id,
                Naziv = kategorija.Naziv
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Izmeni(IzmeniKategorijuViewModel model)
        {
            if (!ModelState.IsValid) //proverava da li je ime i uneseno kako treba
            {
                return View(model);
            }

            var kategorija = this.dbContext.Kategorije.Find(model.Id);
            if (kategorija == null)
            {
                return NotFound(); //404
            }
            kategorija.Naziv = model.Naziv;

            this.dbContext.SaveChanges(); //prihvatamo izmene u dbcontextu

            return RedirectToAction("Index");
        }

        public IActionResult Izbrisi(int id)
        {
            var kategorija = this.dbContext.Kategorije.Find(id);
            if (kategorija == null)
            {
                return NotFound(); //404
            }

            var model = new IzbrisiKategorijuViewModel //pretvara u view model
            {
                Id = kategorija.Id,
                Naziv = kategorija.Naziv
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Izbrisi(int id, object _)
        {
            var kategorija = this.dbContext.Kategorije.Find(id);
            if (kategorija == null)
            {
                return NotFound(); //404
            }
            this.dbContext.Kategorije.Remove(kategorija);

            this.dbContext.SaveChanges(); //prihvatamo izmene u dbcontextu

            return RedirectToAction("Index");
        }
    }
}