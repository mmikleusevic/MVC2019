using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PozdravSvijete.Controllers
{
    public class GenIzlazController : Controller
    {
        // GET: GenIzlaz
        public ActionResult PopisKosarice()
        {
            return View();
        }
        public ActionResult ListaArtikala()
        {
            string[] lista = new string[] { "Skije", "Pancerice", "Sunčane naočale" };
            ViewBag.Lista = lista;
            return View();
        }
    }
}