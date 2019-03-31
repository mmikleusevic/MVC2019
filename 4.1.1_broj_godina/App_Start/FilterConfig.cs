using System.Web;
using System.Web.Mvc;

namespace _4._1._1_broj_godina
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
