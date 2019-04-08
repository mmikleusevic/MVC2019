using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adonet_spajanje_na_bazu.Controllers
{
    public class SqlConnectionObjectController : Controller
    {
        // GET: SqlConnectionObject
        // Direktno
        public ActionResult Index()
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbAlgebra;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    Response.Write("Konekcija uspjela");
                }
                else
                {
                    Response.Write("Neuspješna konekcija");
                }
            }
            catch (SqlException sqlEx)
            {
                Response.Write(sqlEx.Message);
            }
            finally
            {
                conn.Close();
            }
            return View();
        }
        // Preko Web.Config
        public ActionResult SpojPrekoWebConfig()
        {
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnStrSql"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    Response.Write("Konekcija uspjela");
                }
                else
                {
                    Response.Write("Neuspješna konekcija");
                }
            }
            catch (SqlException sqlEx)
            {
                Response.Write(sqlEx.Message);
            }
            finally
            {
                conn.Close();
            }
            return View();
        }
    }
}