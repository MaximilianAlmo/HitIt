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
    public class collaborationfilesController : Controller
    {
        private af6947Entities4 db = new af6947Entities4();

        // GET: collaborationfiles
        public ActionResult Index()
        {
            var collaborationfiles = db.collaborationfiles.Include(c => c.collaborations);
            return View(collaborationfiles.ToList());
        }

        // GET: collaborationfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            collaborationfiles collaborationfiles = db.collaborationfiles.Find(id);
            if (collaborationfiles == null)
            {
                return HttpNotFound();
            }
            return View(collaborationfiles);
        }

        // GET: collaborationfiles/Create
        public ActionResult Create()
        {
            ViewBag.collaborationID = new SelectList(db.collaborations, "colid", "ColName");
            return View();
        }

        // POST: collaborationfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "collaborationFileId,collaborationID,collaborationFile")] collaborationfiles collaborationfiles)
        {
            if (ModelState.IsValid)
            {
                db.collaborationfiles.Add(collaborationfiles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.collaborationID = new SelectList(db.collaborations, "colid", "ColName", collaborationfiles.collaborationID);
            return View(collaborationfiles);
        }

        // GET: collaborationfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            collaborationfiles collaborationfiles = db.collaborationfiles.Find(id);
            if (collaborationfiles == null)
            {
                return HttpNotFound();
            }
            ViewBag.collaborationID = new SelectList(db.collaborations, "colid", "ColName", collaborationfiles.collaborationID);
            return View(collaborationfiles);
        }

        // POST: collaborationfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "collaborationFileId,collaborationID,collaborationFile")] collaborationfiles collaborationfiles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collaborationfiles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.collaborationID = new SelectList(db.collaborations, "colid", "ColName", collaborationfiles.collaborationID);
            return View(collaborationfiles);
        }

        // GET: collaborationfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            collaborationfiles collaborationfiles = db.collaborationfiles.Find(id);
            if (collaborationfiles == null)
            {
                return HttpNotFound();
            }
            return View(collaborationfiles);
        }

        // POST: collaborationfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            collaborationfiles collaborationfiles = db.collaborationfiles.Find(id);
            db.collaborationfiles.Remove(collaborationfiles);
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
