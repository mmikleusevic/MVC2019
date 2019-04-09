using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adonet_spajanje_na_bazu.Controllers
{
    public class SqlCommandObjectController : Controller
    {
        // GET: SqlCommandObject
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnStrSql"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string cmdText = "";

                  cmdText += "INSERT INTO tblTecajevi (naziv,opis) VALUES ('Web Design', 'Naučite dizajnirati web stranice.')";
               // cmdText += "INSERT INTO tblTecajevi ";
               // cmdText += "(naziv,opis)";
               // cmdText += "VALUES ";
               // cmdText += "('Web Design', 'Naučite dizajnirati web stranice.') ";

                // Kreiramo command objekt i otvaramo vezu s bazom
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Connection.Open();

                //Komandu izvršavamo metodom ExecuteNonQuery
                //Ako je zapis upisan u bazu, baza vraća 1 (jer je upisan jedan redak)

                int brojDodanihRedaka = cmd.ExecuteNonQuery();
                if(brojDodanihRedaka > 0)
                {
                    ViewBag.Message = "Zapis je upisan u bazu!";
                }
                else
                {
                    ViewBag.Message = "Dogodila se greška!";
                }
            }
            return View("Index");
        }
        public ActionResult Edit()
        {
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnStrSql"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string cmdText = "";

                cmdText += "UPDATE [dbo].[tblTecajevi]"
                           +" SET "
                           +"[naziv] = 'Web Dev',"
                           +"[opis] = 'Web development'"
                           +"WHERE tblTecajevi.id=1";

                // Kreiramo command objekt i otvaramo vezu s bazom
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Connection.Open();

                //Komandu izvršavamo metodom ExecuteNonQuery
                //Ako je zapis upisan u bazu, baza vraća 1 (jer je upisan jedan redak)

                int brojDodanihRedaka = cmd.ExecuteNonQuery();
                if (brojDodanihRedaka > 0)
                {
                    ViewBag.Message = "Zapis je updatean u bazu!";
                }
                else
                {
                    ViewBag.Message = "Dogodila se greška!";
                }
            }
            return View("Index");
        }
        public ActionResult Delete()
        {
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnStrSql"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string cmdText = "";

                cmdText += "DELETE FROM [dbo].[tblTecajevi]"
                           + "WHERE tblTecajevi.id=2";

                // Kreiramo command objekt i otvaramo vezu s bazom
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Connection.Open();

                //Komandu izvršavamo metodom ExecuteNonQuery
                //Ako je zapis upisan u bazu, baza vraća 1 (jer je upisan jedan redak)

                int brojDodanihRedaka = cmd.ExecuteNonQuery();
                if (brojDodanihRedaka > 0)
                {
                    ViewBag.Message = "Zapis je obrisan u bazu!";
                }
                else
                {
                    ViewBag.Message = "Dogodila se greška!";
                }
            }
            return View("Index");
        }
        public ActionResult Count()
        {
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnStrSql"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string cmdText = "";

                cmdText += "SELECT count(*) FROM [dbo].[tblTecajevi]";

                // Kreiramo command objekt i otvaramo vezu s bazom
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Connection.Open();

                //Komandu izvršavamo metodom ExecuteNonQuery
                //Ako je zapis upisan u bazu, baza vraća 1 (jer je upisan jedan redak)

                int brojDodanihRedaka = (int)cmd.ExecuteScalar();

                if (brojDodanihRedaka > 0)
                {
                    ViewBag.Message = "U tablici se nalazi "+brojDodanihRedaka+" zapisa";
                }
                else
                {
                    ViewBag.Message = "Dogodila se greška!";
                }
            }
            return View("Index");
        }
    }
}