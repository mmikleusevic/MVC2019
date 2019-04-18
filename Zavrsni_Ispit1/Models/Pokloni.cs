using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zavrsni_Ispit1.Models
{
    public class Pokloni
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string naziv { get; set; }
        public string opis { get; set; }
        public bool   kupljeno { get; set; }
    }
}