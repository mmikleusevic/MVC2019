using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;
using System.Data.Entity;

namespace WebShop.Controllers
{
    public class WebShopController : Controller
    {
        private WebShopEntities db = new WebShopEntities();
        // GET: WebShop
        public ActionResult Index()
        {
            var proizvodi = db.Proizvodis.Include(p => p.MjereProizvoda);

            return View(proizvodi.ToList());
        }
    }
}