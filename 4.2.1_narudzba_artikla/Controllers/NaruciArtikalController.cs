using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _4._2._1_narudzba_artikla.Models;

namespace _4._2._1_narudzba_artikla.Controllers
{
    public class NaruciArtikalController : Controller
    {
        // GET: NaruciArtikal
        public ViewResult NaruciArtikal()
        {
            return View(new Artikl());
        }
        [HttpPost]
        public ViewResult NaruciArtikal(Artikl artikal)
        {
            if (artikal.Kolicina > 10)
            {
                ViewBag.Poruka = "Nema dovoljno " + artikal.Naziv + " na skladištu!";
                return View(artikal);
            }
            else
            {
                ViewBag.Poruka = " Naručeno je " +
                    artikal.Kolicina +
                    " komada " +
                    artikal.Naziv +
                    " sa ukupnom cijenom " +
                    artikal.Cijena * artikal.Kolicina;
                return View(artikal);
            }
        }
    }
}