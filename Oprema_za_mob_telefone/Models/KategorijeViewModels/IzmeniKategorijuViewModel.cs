﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oprema_za_mob_telefone.Models.KategorijeViewModels
{
    public class IzmeniKategorijuViewModel
    {
        public int Id { get; set; }
        [Required] //mora da ima vrednost
        [MaxLength(50)]
        public string Naziv { get; set; }
    }
}
