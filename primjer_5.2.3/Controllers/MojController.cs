using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace primjer_5._2._3.Controllers
{
    public class MojController : Controller
    {
        // GET: Moj
        public ViewResult SwitchView()
        {
            return View();
        }
        public ViewResult ViewZaForPetlju()
        {
            string[] voce =
            {
                "Jabuka",
                "Kruška",
                "Šljiva",
                "Gljiva",
                "Banana"
            };
            return View((object)voce);
        }
    }
}