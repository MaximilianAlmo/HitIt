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
    public class PictureController : Controller
    {
        //
        // GET: /Picture/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Picture/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Picture/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Picture/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Picture/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Picture/Edit/5
        [HttpPost]
        public ActionResult Edit(HttpPostedFileClass profile2)
        {
            
        
        
            return RedirectToAction("Index");
        }

        //
        // GET: /Picture/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Picture/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
