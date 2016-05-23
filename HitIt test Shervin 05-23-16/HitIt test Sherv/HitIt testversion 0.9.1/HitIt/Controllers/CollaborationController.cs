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
    public class CollaborationController : Controller
    {
        private af6947Entities4 db = new af6947Entities4();

        // GET: /Collaboration/
        public ActionResult Index()
        {
            var collaborations = db.collaborations.Include(c => c.profile);
            return View(collaborations.ToList());
        }

        // GET: /Collaboration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            collaborations collaborations = db.collaborations.Find(id);
            if (collaborations == null)
            {
                return HttpNotFound();
            }
            return View(collaborations);
        }

        // GET: /Collaboration/Create
        public ActionResult Create()
        {
            ViewBag.profileId = new SelectList(db.profile, "id", "profileName");
            return View();
        }

        // POST: /Collaboration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="profileId,colid,ColName,genre,colOwner,ColFile")] collaborations collaborations)
        {
            if (ModelState.IsValid)
            {
                db.collaborations.Add(collaborations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.profileId = new SelectList(db.profile, "id", "profileName", collaborations.profileId);
            return View(collaborations);
        }

        // GET: /Collaboration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            collaborations collaborations = db.collaborations.Find(id);
            if (collaborations == null)
            {
                return HttpNotFound();
            }
            ViewBag.profileId = new SelectList(db.profile, "id", "profileName", collaborations.profileId);
            return View(collaborations);
        }

        // POST: /Collaboration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="profileId,colid,ColName,genre,colOwner,ColFile")] collaborations collaborations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collaborations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.profileId = new SelectList(db.profile, "id", "profileName", collaborations.profileId);
            return View(collaborations);
        }

        // GET: /Collaboration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            collaborations collaborations = db.collaborations.Find(id);
            if (collaborations == null)
            {
                return HttpNotFound();
            }
            return View(collaborations);
        }

        // POST: /Collaboration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            collaborations collaborations = db.collaborations.Find(id);
            db.collaborations.Remove(collaborations);
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
