using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FilmManagementSystemMVC.Controllers
{
    public class LoginRegistrationController : Controller
    {
        SqlConnection conn =
       new SqlConnection(@"Data Source=192.168.1.31,1433;Initial Catalog=20June Dot NetBatch;User ID=Sqluser;Password=sqluser");
        SqlCommand cmd;
        // GET: LoginRegistration
        [HttpGet]
        public ActionResult LoginIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginIndex(FormCollection formCollection)
        {

            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[PRAVEEN].USP_CheckLogin";
            cmd.Parameters.AddWithValue("@Email", formCollection["Email"]);
            cmd.Parameters.AddWithValue("@Password", formCollection["Password"]);
            cmd.Connection = conn;

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                Session["isAuthenticated"] = formCollection["Email"];
            
                FormsAuthentication.SetAuthCookie(formCollection["Email"],true);
                return RedirectToAction("HomePage", "Home");
            }
            // int result = cmd.ExecuteNonQuery();
            conn.Close();

            /*if (result > 0)
            {
                Response.Write("Login successful");
                Session["isAuthenticated"] = formCollection["Email"];
            }
            else
                Response.Write("Invalid Credientials");*/
            return View();
        }

        [HttpGet]
        public ActionResult RegistrationIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrationIndex(FormCollection formCollection)
        {

            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[PRAVEEN].USP_Registration";
            cmd.Parameters.AddWithValue("@FirstName", formCollection["FirstName"]);
            cmd.Parameters.AddWithValue("@LastName", formCollection["LastName"]);
            cmd.Parameters.AddWithValue("@Email", formCollection["Email"]);
            cmd.Parameters.AddWithValue("@Password", formCollection["Password"]);
            cmd.Parameters.AddWithValue("@ConfirmPassword", formCollection["ConfirmPassword"]);
            cmd.Connection = conn;

            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();

            if (result > 0)
                Response.Write("<alert>Registration successful</alert>");
            else
                Response.Write("<alert>Registration NOT Done</alert>");
            return View();
        }
    }
}