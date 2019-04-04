using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _6._2_primjer.Models;

namespace _6._2_primjer.Controllers
{
    public class MetaDataHtmlHelperiController : Controller
    {
        // GET: MetaDataHtmlHelperi
        public ViewResult MetaDataView()
        {
            return View(new OsobaMeta());
        }
        [HttpPost]
        public ViewResult MetaDataView(OsobaMeta osoba)
        {
            return View("HtmlLabelDisplay", osoba);
        }
    }
}