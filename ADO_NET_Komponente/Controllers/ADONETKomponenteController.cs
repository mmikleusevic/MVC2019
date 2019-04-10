using ADO_NET_Komponente.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADO_NET_Komponente.Controllers
{
    public class ADONETKomponenteController : Controller
    {
        public static string connStr = ConfigurationManager.ConnectionStrings["dbAlgebraConnStrSql"].ConnectionString;
        // GET: ADONETKomponente
        public ActionResult List()
        {
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cm = new SqlCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM tblPolaznici";

            SqlDataReader dr = null;
            List<PolaznikModel> lstPolaznici = new List<PolaznikModel>();
            try
            {
                conn.Open();
                dr = cm.ExecuteReader();

                if(dr != null)
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            PolaznikModel polaznik = new PolaznikModel();
                            polaznik.IdPolaznik = int.Parse(dr["id"].ToString());
                            polaznik.Ime = dr["ime"].ToString();
                            polaznik.Prezime = dr["prezime"].ToString();
                            polaznik.Email = dr["email"].ToString();
                            polaznik.DatumRodjenja = DateTime.Parse(dr["datumRodjenja"].ToString());
                            lstPolaznici.Add(polaznik);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa polaznika! Opis: " + ex.Message;
            }
            finally
            {
                if(dr != null)
                {
                    dr.Close();
                }
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
                cm.Dispose();
            }
            return View(lstPolaznici);
        }
        [HttpGet]
        public ActionResult Details(int IdPolaznik)
        {
            SqlConnection conn = new SqlConnection(connStr);

            string cmdText = "SELECT * from tblPolaznici WHERE id=@id";

            SqlCommand cmd = new SqlCommand(cmdText,conn);

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@id";
            param.DbType = DbType.Int32;
            param.Direction = ParameterDirection.Input;
            param.Value = IdPolaznik;
            cmd.Parameters.Add(param);

            SqlDataReader dr = null;
            PolaznikModel polaznik = new PolaznikModel();
            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            polaznik.IdPolaznik = int.Parse(dr["id"].ToString());
                            polaznik.Ime = dr["ime"].ToString();
                            polaznik.Prezime = dr["prezime"].ToString();
                            polaznik.Email = dr["email"].ToString();
                            polaznik.DatumRodjenja = DateTime.Parse(dr["datumRodjenja"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa polaznika! Opis: " + ex.Message;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
                cmd.Dispose();
            }
            return View(polaznik);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new PolaznikModel());
        }
        [HttpPost]
        public ActionResult Create(PolaznikModel model)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connStr))
                {
                    string cmdText = "";
                    cmdText += "INSERT INTO tblPolaznici (ime,prezime,email,datumRodjenja) VALUES ('"+model.Ime+"','"+model.Prezime+"','"+model.Email+"','"+model.DatumRodjenja.ToString("yyy-MM-dd")+"')";

                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Connection.Open();

                    int brojDodanihRedaka = cmd.ExecuteNonQuery();
                    ViewBag.Message = "Broj dodanih redaka: " + brojDodanihRedaka;
                }
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Greška kod upisa polaznika! Opis: " + ex.Message;
            }
            return View(model);    
        }
        [HttpGet]
        public ActionResult Edit(int IdPolaznik)
        {
            SqlConnection conn = new SqlConnection(connStr);

            string cmdText = "SELECT * from tblPolaznici WHERE id=@id";

            SqlCommand cmd = new SqlCommand(cmdText, conn);

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@id";
            param.DbType = DbType.Int32;
            param.Direction = ParameterDirection.Input;
            param.Value = IdPolaznik;
            cmd.Parameters.Add(param);

            SqlDataReader dr = null;
            PolaznikModel polaznik = new PolaznikModel();
            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            polaznik.IdPolaznik = int.Parse(dr["id"].ToString());
                            polaznik.Ime = dr["ime"].ToString();
                            polaznik.Prezime = dr["prezime"].ToString();
                            polaznik.Email = dr["email"].ToString();
                            polaznik.DatumRodjenja = DateTime.Parse(dr["datumRodjenja"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja polaznika! Opis: " + ex.Message;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
                cmd.Dispose();
            }
            return View(polaznik);
        }
        [HttpPost]
        public ActionResult Edit(PolaznikModel model)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string cmdText = "";
                    cmdText += "UPDATE tblPolaznici ";
                    cmdText += "SET ime='"+model.Ime+"',prezime='"+model.Prezime+"',email='"+model.Email+"',datumRodjenja='"+model.DatumRodjenja.ToString("yyy-MM-dd")+"' ";
                    cmdText += "WHERE id="+model.IdPolaznik;

                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Connection.Open();

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
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod upisa polaznika! Opis: " + ex.Message;
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Delete(int idPolaznik)
        {
            SqlConnection conn = new SqlConnection(connStr);
            string cmdText = "DELETE FROM tblPolaznici Where id="+idPolaznik;
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            try
            {
                cmd.Connection.Open();
                int brojBrisanihRedaka = cmd.ExecuteNonQuery();
                TempData["Message"] = "Broj izbrisanih redaka: " + brojBrisanihRedaka;
            }
            catch(Exception ex)
            {
                ViewBag.Message = "Greška kod brisanja polaznika! Opis: " + ex.Message;
            }
            finally
            {
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
                cmd.Dispose();
            }
            return RedirectToAction("List");
        }
    }
}