using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oprema_za_mob_telefone.Data;
using Microsoft.EntityFrameworkCore;
using Oprema_za_mob_telefone.Models.KorpaViewModels;

namespace Oprema_za_mob_telefone.Controllers
{
    [Authorize]
    public class KorpaController:Controller
    {
        private readonly ApplicationDbContext dbContext;

        public KorpaController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var korisnik = dbContext.Users.Single(x => x.Email == User.Identity.Name);
            var izabraniProizvodi = dbContext.IzabraniProizvodi.Include(x => x.Proizvod)
                .Where(x => x.Korisnik.Id == korisnik.Id)
                .Select(x => new IzabraniProizvodViewModel {
                    Id = x.Id,
                    Naziv = x.Proizvod.Naziv,
                    Slika = x.Proizvod.Slika,
                    Cena = x.Proizvod.Cena,
                    Kolicina = x.Kolicina
                }).ToArray();

            return View(izabraniProizvodi);
        }

        [HttpPost]
        public IActionResult Obrisi(int id)
        {
            var izabraniProizvod = dbContext.IzabraniProizvodi.Find(id);
            if(izabraniProizvod == null)
            {
                return NotFound();
            }

            dbContext.IzabraniProizvodi.Remove(izabraniProizvod);
            dbContext.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IActionResult Sacuvaj(int id, int kolicina)
        {
            var izabraniProizvod = dbContext.IzabraniProizvodi.Find(id);
            if (izabraniProizvod == null)
            {
                return NotFound();
            }

            izabraniProizvod.Kolicina = kolicina;
            dbContext.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IActionResult Dodaj(int id)
        {
            var proizvod = dbContext.Proizvodi.Find(id);
            if (proizvod == null)
            {
                return NotFound();
            }

            var korisnik = dbContext.Users.SingleOrDefault(x => x.Email == User.Identity.Name);

            var izabraniProizvod = dbContext.IzabraniProizvodi.SingleOrDefault(x => x.Korisnik == korisnik && x.Proizvod == proizvod);

            if (izabraniProizvod == null)
            {
                izabraniProizvod = new IzabraniProizvod
                {
                    Proizvod = proizvod,
                    Korisnik = korisnik,
                    Kolicina = 1
                };
                dbContext.IzabraniProizvodi.Add(izabraniProizvod);
            }
            else
            {
                izabraniProizvod.Kolicina++;
            }

            dbContext.SaveChanges();

            return Ok();// vraca 200
        }
    }
}
