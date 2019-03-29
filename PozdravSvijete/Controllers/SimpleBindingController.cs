using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PozdravSvijete.Controllers
{
    public class SimpleBindingController : Controller
    {
        // GET: SimpleBinding
        public ViewResult SimpleBindMetoda()
        {
            return View("SimpleBindMetoda");
        }
        [HttpPost]
        public ViewResult SimpleBindMetoda(string ime)
        {
            string pozdrav = "Pozdrav, " + ime + "!";
            return View("SimpleBindMetoda", (object)pozdrav);
        }
    }
}