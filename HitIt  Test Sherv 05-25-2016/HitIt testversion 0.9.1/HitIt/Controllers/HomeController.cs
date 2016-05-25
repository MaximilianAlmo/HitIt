using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using HitIt.Models;
using System.IO;
using MySql.Data.MySqlClient;

namespace HitIt.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Data()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Data(HttpPostedFileClass profile2)
        {

            if (profile2.file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(profile2.file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Pictures/profilePictures"), fileName);
                profile2.file.SaveAs(path);

                string connectString = "SERVER= 195.178.232.16; PORT=3306; DATABASE=af6947;UID=af6947 ;PASSWORD=sexyKalle79;";
                MySqlConnection connection = new MySqlConnection(connectString);
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT id FROM profile WHERE UserName ='" + User.Identity.Name + "'";
                Int32 userEdit = (Int32)cmd.ExecuteScalar();
                cmd.CommandText = "UPDATE profile SET picturePath=@picturePath WHERE UserName ='" + User.Identity.Name + "' AND id ='" + userEdit + "'";
                cmd.Parameters.Add("@UserName", userEdit);
                cmd.Parameters.Add("@picturePath", fileName);
                cmd.ExecuteNonQuery();
                connection.Close();

            }
            else
            {

            }

            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Profile()
        {
            ViewBag.Message = "Your profile page.";

            return View();
        }
        public ActionResult Collaborations()
        {
            ViewBag.Message = "Your profile page.";

            return View();
        }
    }
}