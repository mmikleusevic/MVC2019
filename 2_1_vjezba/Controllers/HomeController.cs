using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2_1_vjezba.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string message = "Rezultat operacije 4 + 3 * 3 = ";
            return View((object)message);
        }
    }
}