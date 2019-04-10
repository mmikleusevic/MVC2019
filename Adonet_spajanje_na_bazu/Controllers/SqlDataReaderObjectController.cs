using Adonet_spajanje_na_bazu.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adonet_spajanje_na_bazu.Controllers
{
    public class SqlDataReaderObjectController : Controller
    {
        // GET: SqlDataReaderObject
        public ActionResult Index()
        {
            List<Tecaj> lstTecajevi = new List<Tecaj>();
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnStrSql"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string cmdText = "";

                cmdText += "SELECT * FROM [dbo].[tblTecajevi]";

                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader != null)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Tecaj t1 = new Tecaj();
                            t1.Id = (int)reader["id"];
                            t1.Naziv = (string)reader["naziv"];
                            t1.Opis = (string)reader["opis"];
                            lstTecajevi.Add(t1);
                        }
                    }
                }
                reader.Close();
            }
            return View(lstTecajevi);
        }
    }
}