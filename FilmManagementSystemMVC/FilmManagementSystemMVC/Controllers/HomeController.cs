using FilmManagementSystemMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FilmManagementSystemMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        FMSEntities db = new FMSEntities();
        public ActionResult HomePage()
        {
            if (Session["isAuthenticated"] == null)
                return RedirectToAction("LoginIndex", "LoginRegistration");
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Film Management System...!";

            return View();
        }
        public ActionResult Logout()
        {
            Session["isAuthenticated"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("LoginIndex", "LoginRegistration");
        }
        [HttpPost, ActionName("HomePage")]
        public ActionResult HomePagep()
        {
            Session["isAuthenticated"] = null;
            return RedirectToAction("LoginIndex", "LoginRegistration");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Reach Us Here....";

            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}