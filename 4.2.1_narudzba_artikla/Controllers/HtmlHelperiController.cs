using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _4._2._1_narudzba_artikla.Models;

namespace _4._2._1_narudzba_artikla.Controllers
{
    public class HtmlHelperiController : Controller
    {
        // GET: HtmlHelperi
        public ActionResult Index()
        {
            return View();
        }
        private string[] mjesta = new string[]
        {
            " Split"," Osijek"," Zadar"," Rijeka"
        };
        public ViewResult FormHelper()
        {
            ViewBag.Mjesta = this.mjesta;
            return View(new Osoba());
        }
        [HttpPost]
        public ViewResult FormHelper(Osoba osoba)
        {
            ViewBag.Mjesta = this.mjesta;
            ViewBag.Poruka = "Podaci uneseni";
            return View(osoba);
        }
        public ViewResult StrongTypeFormHelper()
        {
            ViewBag.Mjesta = this.mjesta;
            return View(new Osoba());
        }
        [HttpPost]
        public ViewResult StrongTypeFormHelper(Osoba osoba)
        {
            ViewBag.Mjesta = this.mjesta;
            ViewBag.Poruka = "Podaci uneseni";
            return View(osoba);
        }
    }

}