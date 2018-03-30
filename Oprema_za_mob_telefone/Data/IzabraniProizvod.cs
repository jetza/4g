using Oprema_za_mob_telefone.Models;

namespace Oprema_za_mob_telefone.Data
{
    public class IzabraniProizvod
    {
        public int Id { get; set; }
        public Proizvod Proizvod { get; set; }
        public ApplicationUser Korisnik { get; set; }
        public int Kolicina { get; set; }
    }
}
