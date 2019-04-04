using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _6._1._1_zadatak.Models;

namespace _6._1._1_zadatak.Controllers
{
    public class ListaArtikalaController : Controller
    {
        // GET: ListaArtikala
        public ActionResult UnesiArtikl()
        {
            ViewBag.Kategorije = new string[] { "Sport", "Glazba", "Tehnika" };
            return View(new Artikl());
        }
        [HttpPost]
        public ActionResult DodajArtikl(Artikl artikl)
        {
            if (Session["Artikli"] != null)
            {
                List<Artikl> artikli = (List <Artikl>)Session["Artikli"];
                artikli.Add(artikl);
                Session["Artikli"] = artikli;
            }
            else
            {
                List<Artikl> artikli = new List<Artikl>();
                artikli.Add(artikl);
                Session["Artikli"] = artikli;
            }
            return View(Session["Artikli"]);
        }
    }
}