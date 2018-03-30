using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oprema_za_mob_telefone.Data
{
    public class Proizvod
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public Kategorija Kategorija { get; set; }
        public string Opis { get; set; }
        public string Slika { get; set; }
    }
}
