using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oprema_za_mob_telefone.Models.ProizvodiViewModels
{
    public class KreirajProizvodViewModel
    {
        [Required] //mora da ima vrednost
        [MaxLength(50)]
        public string Naziv { get; set; }
        [Display(Name = "Kategorija")]
        public int KategorijaId { get; set; }
        public string Opis { get; set; }
        public string Slika { get; set; }

        public IEnumerable<LookupItemViewModel> Kategorije { get; set; }
    }
}
