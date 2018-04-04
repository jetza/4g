using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oprema_za_mob_telefone.Models.HomeViewModels
{
    public class ProizvodViewModel
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        [Display(Name = "Kategorija")]
        public string NazivKategorije { get; set; }
        public decimal Cena { get; set; }
        public string Opis { get; set; }
        public string Slika { get; set; }
    }
}
