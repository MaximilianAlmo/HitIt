using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HitIt.Models;

namespace HitIt.Controllers
{
    public class collaborationsController : Controller
    {
        private af6947Entities db = new af6947Entities();

        // GET: collaborations
        public ActionResult Index()
        {
            var collaboration = db.collaboration.Include(c => c.profile);
            return View(collaboration.ToList());
        }

        // GET: collaborations/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            collaboration collaboration = db.collaboration.Find(id);
            if (collaboration == null)
            {
                return HttpNotFound();
            }
            return View(collaboration);
        }

        // GET: collaborations/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.profile, "id", "name");
            return View();
        }

        // POST: collaborations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name1,genre,files,owners,description")] collaboration collaboration)
        {
            if (ModelState.IsValid)
            {
                db.collaboration.Add(collaboration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.profile, "id", "name", collaboration.id);
            return View(collaboration);
        }

        // GET: collaborations/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            collaboration collaboration = db.collaboration.Find(id);
            if (collaboration == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.profile, "id", "name", collaboration.id);
            return View(collaboration);
        }

        // POST: collaborations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name1,genre,files,owners,description")] collaboration collaboration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collaboration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.profile, "id", "name", collaboration.id);
            return View(collaboration);
        }

        // GET: collaborations/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            collaboration collaboration = db.collaboration.Find(id);
            if (collaboration == null)
            {
                return HttpNotFound();
            }
            return View(collaboration);
        }

        // POST: collaborations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            collaboration collaboration = db.collaboration.Find(id);
            db.collaboration.Remove(collaboration);
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
