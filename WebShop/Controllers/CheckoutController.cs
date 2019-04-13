using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;
using System.Data.Entity;
using System.Net;
using System.Data;
using System.Data.Entity.Validation;

namespace WebShop.Controllers
{
    public class CheckoutController : Controller
    {
        private WebShopEntities db = new WebShopEntities();
        // GET: Checkout
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser([Bind(Include ="Id,Ime,Prezime,Email,AdresaDostave,Kontakt,Napomena")] Korisnici korisnici)
        {
            if (ModelState.IsValid)
            {
                db.Korisnicis.Add(korisnici);
                db.SaveChanges();
                return RedirectToAction("CreateOrder", korisnici);
            }
            return View(korisnici);
        }
        public ActionResult CreateOrder(Korisnici korisnici)
        {
            Narudzbe narudzba = new Narudzbe();
            narudzba.KorisnikId = korisnici.Id;
            narudzba.Prezime = korisnici.Prezime;
            narudzba.Email = korisnici.Email;
            narudzba.DatumKreiranja = 
                Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            narudzba.DatumVrijemeDostave =
                Convert.ToDateTime(DateTime.Now.AddDays(7).ToString("yyyy-MM-dd"));
            narudzba.JeDostavljeno = false;
            db.Narudzbes.Add(narudzba);
            db.SaveChanges();
           

            int narudzbaId = narudzba.Id;

            if (Session["Cart"] != null)
            {
                List<Proizvodi> lstproizvodi = Session["Cart"] as List<Proizvodi>;

                List<int> distinctProizvodi = (from proiz in lstproizvodi
                                               select proiz.Id).Distinct().ToList();

                foreach (int distItem in distinctProizvodi)
                {
                    NarudzbeDetalji detalji = new NarudzbeDetalji();
                    detalji.NarudzbaId = narudzbaId;
                    detalji.ProizvodId = distItem;
                    detalji.Kolicina = lstproizvodi.Where(x => x.Id == distItem).Count();
                    detalji.JedCijena = lstproizvodi.Where(x => x.Id == distItem).FirstOrDefault().Cijena;
                    db.NarudzbeDetaljis.Add(detalji);
                    db.SaveChanges();
                    
                }
                Session["narudzbaId"] = narudzbaId;
                return RedirectToAction("OrderDetails");
            }
            return RedirectToAction("Index", "Cart");
        }
        public ActionResult OrderDetails()
        {
            int id = int.Parse(Session["narudzbaId"].ToString());
            Narudzbe narudzba = db.Narudzbes.Find(id);
            if(narudzba == null)
            {
                return HttpNotFound();
            }
            List<NarudzbeDetalji> lstDetalji = (from detalji in db.NarudzbeDetaljis
                                                where detalji.NarudzbaId == id
                                                select detalji).ToList();

            ViewBag.Detalji = lstDetalji;
            return View(narudzba);
        }
        public ActionResult Confirm()
        {
            Session["Cart"] = null;
            return RedirectToAction("Index", "WebShop");
        }
    }
}