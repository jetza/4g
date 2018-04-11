using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oprema_za_mob_telefone.Data;

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
