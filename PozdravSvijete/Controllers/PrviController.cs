using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PozdravSvijete.Controllers
{
    public class PrviController : Controller
    {
        // GET: Prvi/MetodaSParametrima/{id}
        public ActionResult MetodaSParametrima(int id)
        {
            // return View();
            return Content(id.ToString());
        }

        //GET: Drugi/DrugaMetodaSParametrima/{id}
        public ViewResult DrugaMetodaSParametrima(int id)
        {
            return View((object)id);
            //return Content(id.toString());
        }
    }
}