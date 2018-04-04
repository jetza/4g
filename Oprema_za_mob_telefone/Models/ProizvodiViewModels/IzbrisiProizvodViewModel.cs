using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oprema_za_mob_telefone.Models.ProizvodiViewModels
{
    public class IzbrisiProizvodViewModel
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int KategorijaId { get; set; }
        public string Opis { get; set; }
        public string Slika { get; set; }
        public IEnumerable<LookupItemViewModel> Kategorije { get; set; }

    }
}
