using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4._1._1_broj_godina.Controllers
{
    public class TocanOdgovorController : Controller
    {
        // GET: ProvjeriOdgovor
        public ViewResult ProvjeriOdgovor()
        {
            return View();
        }
        [HttpPost]
        public ViewResult ProvjeriOdgovor(string odgovor)
        {
            string rezultat;
            if (!string.IsNullOrEmpty(odgovor))
            {
                if (odgovor == "Bruxelles")
                {
                    rezultat = "Odgovor je točan";
                    return View((object)rezultat);
                }
                else
                {
                    rezultat = "Odgovor je netočan!";
                    return View((object)rezultat);
                }
            }
            else
            {
                rezultat = "Odgovor ne postoji!";
                return View((object)rezultat);
            }
        }
    }
}