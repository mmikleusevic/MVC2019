using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Zavrsni_Ispit1.Models;

namespace Zavrsni_Ispit1.Controllers
{
    public class IspitController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Ispit
        public ActionResult prvi()
        {
            DateTime date = DateTime.Now;
            return View(date);
        }

        public ActionResult Popis()
        {

            List<Pokloni> lPoklona = (from p in _db.Pokloni
                                     where p.kupljeno == false
                                     select p).ToList();
            return View(lPoklona);
        }

        public ActionResult listaSvihPoklona()
        {
            List<Pokloni> lPoklona = (from p in _db.Pokloni
                                     select p).ToList();
            return View(lPoklona);
        }

        public ActionResult DodajPoklon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DodajPoklon(Pokloni pokloni)
        {
            if (ModelState.IsValid)
            {
                _db.Pokloni.Add(pokloni);
                _db.SaveChanges();
                return RedirectToAction("listaSvihPoklona");
            }

            return View(pokloni);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pokloni pokloni = _db.Pokloni.Find(id);
            if (pokloni == null)
            {
                return HttpNotFound();
            }
            return View(pokloni);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Pokloni pokloni = _db.Pokloni.Find(id);

            if (pokloni == null)
            {
                return HttpNotFound();
            }

            return View(pokloni);
        }

        [HttpPost]
        public ActionResult Edit(Pokloni pokloni)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(pokloni).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("listaSvihPoklona");
            }

            return View(pokloni);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pokloni pokloni = _db.Pokloni.Find(id);
            if (pokloni == null)
            {
                return HttpNotFound();
            }
            return View(pokloni);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Pokloni pokloni = _db.Pokloni.Find(id);
            _db.Pokloni.Remove(pokloni);
            _db.SaveChanges();
            return RedirectToAction("listaSvihPoklona");
        }
    }
}