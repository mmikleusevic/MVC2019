using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _4._2._1_narudzba_artikla.Models;

namespace _4._2._1_narudzba_artikla.Controllers
{
    public class ParcijalniPogledController : Controller
    {
        // GET: ParcijalniPogled
        public ActionResult PrikaziKosaricu()
        {
            List<Artikl> lArtikal = new List<Artikl>()
            {
                new Artikl() { Naziv="Kruh", Cijena=8.9m, Kolicina=3, Kategorija="Crvena" },
                new Artikl() { Naziv="Sir", Cijena=54.7m, Kolicina=3, Kategorija="Zelena"},
                new Artikl() { Naziv="Mlijeko", Cijena=6.5m, Kolicina=3, Kategorija="Žuta" }
            };
            return View(lArtikal);
        }
    }
}