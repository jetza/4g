using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oprema_za_mob_telefone.Models.KorpaViewModels
{
    public class IzabraniProizvodViewModel
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public decimal Cena { get; set; }
        public string Slika { get; set; }
        public int Kolicina { get; set; }
    }
}
