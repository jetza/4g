using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Oprema_za_mob_telefone.Data;
using Oprema_za_mob_telefone.Models;
using Oprema_za_mob_telefone.Models.ProizvodiViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Oprema_za_mob_telefone.Controllers
{

    [Authorize(Roles = "Admin")]//sakriva proizvode za sve osim admina
    public class ProizvodiController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ProizvodiController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var proizvodi = this.dbContext.Proizvodi.Include(x =>x.Kategorija).ToList(); //ucitava sve proizvode iz baze

            var model = proizvodi.Select(proizvod => new ProizvodViewModel
            {
                Id = proizvod.Id,
                Naziv = proizvod.Naziv,
                NazivKategorije = proizvod.Kategorija.Naziv,
                Cena = proizvod.Cena
            });

            return View(model);
        }

        [HttpGet]
        public IActionResult Kreiraj()
        {
            var model = new KreirajProizvodViewModel
            {
                Kategorije = GetKategorijeLookup()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Kreiraj(KreirajProizvodViewModel model)
        {
            if (!ModelState.IsValid) //proverava da li je ime i uneseno kako treba
            {
                model.Kategorije = GetKategorijeLookup();
                return View(model);
            }

            var proizvod = new Proizvod {
                Naziv = model.Naziv,
                Kategorija = this.dbContext.Kategorije.Find(model.KategorijaId),
                Opis = model.Opis,
                Slika = model.Slika,
                Cena = model.Cena
            };
            this.dbContext.Proizvodi.Add(proizvod); //ubacuje u bazu

            this.dbContext.SaveChanges(); //prihvatamo izmene u dbcontextu

            return RedirectToAction("Index");
        }

        public IActionResult Izmeni(int id)
        {
            var proizvod = this.dbContext.Proizvodi.Include(x => x.Kategorija).Where(x => x.Id == id).SingleOrDefault();
            if (proizvod == null)
            {
                return NotFound(); //404
            }

            var model = new IzmeniProizvodViewModel //pretvara u view model
            {
                Id = proizvod.Id,
                Naziv = proizvod.Naziv,
                KategorijaId = proizvod.Kategorija.Id,
                Opis = proizvod.Opis,
                Slika = proizvod.Slika,
                Kategorije = GetKategorijeLookup(),
                Cena = proizvod.Cena
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Izmeni(IzmeniProizvodViewModel model)
        {
            if (!ModelState.IsValid) //proverava da li je ime i uneseno kako treba
            {
                model.Kategorije = GetKategorijeLookup();
                return View(model);
            }

            var proizvod = this.dbContext.Proizvodi.Find(model.Id);
            if (proizvod == null)
            {
                return NotFound(); //404
            }
            proizvod.Naziv = model.Naziv;
            proizvod.Kategorija = this.dbContext.Kategorije.Find(model.KategorijaId);
            proizvod.Opis = model.Opis;
            proizvod.Slika = model.Slika;
            proizvod.Cena = model.Cena;

            this.dbContext.SaveChanges(); //prihvatamo izmene u dbcontextu

            return RedirectToAction("Index");
        }

        public IActionResult Izbrisi(int id)
        {
            var proizvod = this.dbContext.Proizvodi.Find(id);
            if (proizvod == null)
            {
                return NotFound(); //404
            }

            var model = new IzbrisiProizvodViewModel //pretvara u view model
            {
                Id = proizvod.Id,
                Naziv = proizvod.Naziv
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Izbrisi(int id, object _)
        {
            var proizvod = this.dbContext.Proizvodi.Find(id);
            if (proizvod == null)
            {
                return NotFound(); //404
            }
            this.dbContext.Proizvodi.Remove(proizvod);

            this.dbContext.SaveChanges(); //prihvatamo izmene u dbcontextu

            return RedirectToAction("Index");
        }
        private IQueryable<LookupItemViewModel> GetKategorijeLookup()
        {
            return this.dbContext.Kategorije.Select(kategorija => new LookupItemViewModel
            {
                Id = kategorija.Id,
                Naziv = kategorija.Naziv

            });
        }
    }

}
