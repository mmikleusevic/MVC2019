using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _6._2_primjer.Models
{
    public class OsobaTempl
    {
        public int OsobaID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string MjestoStanovanja { get; set; }
        public string Spol { get; set; }
        public bool Zaposlen { get; set; }
        public DateTime DatumRodenja { get; set; }
        public string Napomena { get; set; }
        public Adresa AdresaOsobe { get; set; }
    }
}