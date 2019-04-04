using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _5._5._1_zadatak.Models;

namespace _5._5._1_zadatak.Controllers
{
    public class PrikazSaChildAkcijomController : Controller
    {
        // GET: PrikazSaChildAkcijom
        public ActionResult ObradiListu()
        {
            List<Artikl> lartikal = new List<Artikl>()
            {
                new Artikl() { Naziv="Kruh", Cijena=8.9m, Kolicina=3, Kategorija="Crvena" },
                new Artikl() { Naziv="Sir", Cijena=54.7m, Kolicina=3, Kategorija="Zelena"},
                new Artikl() { Naziv="Mlijeko", Cijena=6.5m, Kolicina=3, Kategorija="Žuta" }
            };
            return View(lartikal);
        }
        [ChildActionOnly]
        public string OdrediKategoriju(Artikl artikl)
        {
            return artikl.Kategorija;
        }
    }
}
