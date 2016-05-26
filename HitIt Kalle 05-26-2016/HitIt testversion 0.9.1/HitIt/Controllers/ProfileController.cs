using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HitIt.Models;
using System.IO;
using MySql.Data.MySqlClient;

namespace HitIt.Controllers
{
    public class ProfileController : Controller
    {
        private af6947Entities4 db = new af6947Entities4();
        

        // GET: /Profile/
        public ActionResult Index()
        {
            return View(db.profile.ToList());
        }

        // GET: /Profile/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profile profile = db.profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // GET: /Profile/Create
        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]                  //Laddar upp en fil till Content/Pictures/profilePictures
        //public ActionResult Index(profile profile)
        //{
            


        //    return RedirectToAction("Index");
        //}
        //[HttpGet]
        //public ActionResult showPicture(string pPath)
        //{
        //    var connectString1 = "SERVER= 195.178.232.16; PORT=3306; DATABASE=af6947;UID=af6947 ;PASSWORD=sexyKalle79;";

        //    MySqlConnection connectionString1 = new MySqlConnection(connectString1);

        //    MySqlCommand cmd1 = connectionString1.CreateCommand();
        //    using (var cn = new MySqlConnection(connectString1))
        //    using (var cmd = cn.CreateCommand())
        //    {
        //        cn.Open();
        //        cmd.CommandText = "select picturePath from profile where UserName ='" + User.Identity.Name + "'";
        //        cmd.Parameters.AddWithValue("@accountid", 5);
        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            if (reader.Read())
        //            {
        //                pPath = reader.GetString(0);
        //                // For this to work images must be stored inside the web application.
        //                // filePath must be a relative location inside the virtual directory
        //                // hosting the application. Depending on your environment some
        //                // transformations might be necessary on filePath before assigning it
        //                // to the image url.
        //                showPicture.ImageUrl = pPath;
        //            }
        //        }


        //        //    cmd1.CommandText = "SELECT picturePath FROM profile WHERE UserName ='" + User.Identity.Name + "'";
        //        //string userEdit1 = (string)cmd1.ExecuteScalar();
        //        //cmd1.Parameters.ToString(userEdit1)("@picturePath");
        //        //cmd1.ExecuteNonQuery();
        //        //connectionString1.Close();
        //        //pPath = userEdit1;
        //    }
        //}
        // POST: /Profile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,profileName,dateOfBirth,city,country,languages,rating,about,picture,teaser,UserName,picturePath,teaserPath")] profile profile)
        {
            if (ModelState.IsValid)
            {
                db.profile.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profile);
        }

        // GET: /Profile/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profile profile = db.profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: /Profile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,profileName,dateOfBirth,city,country,languages,rating,about,picture,teaser,UserName,picturePath,teaserPath")] profile profile)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {

                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();


                if (Request.IsAuthenticated)
                {
                    string connectString = "SERVER= 195.178.232.16; PORT=3306; DATABASE=af6947;UID=af6947 ;PASSWORD=sexyKalle79;";
                    MySqlConnection connection = new MySqlConnection(connectString);
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT id FROM profile WHERE UserName ='" + User.Identity.Name + "'";
                    Int32 userEdit1 = (Int32)cmd.ExecuteScalar();
                    cmd.ExecuteNonQuery();
                    connection.Close();


                    return RedirectToAction("/Details/" + userEdit1);
                }
            }
            return View(profile);
        }

        // GET: /Profile/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profile profile = db.profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: /Profile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            profile profile = db.profile.Find(id);
            db.profile.Remove(profile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
