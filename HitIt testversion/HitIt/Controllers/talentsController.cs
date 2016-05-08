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
    public class talentsController : Controller
    {
        private af6947Entities db = new af6947Entities();

        // GET: talents
        public ActionResult Index()
        {
            var talent = db.talent.Include(t => t.profile);
            return View(talent.ToList());
        }

        // GET: talents/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            talent talent = db.talent.Find(id);
            if (talent == null)
            {
                return HttpNotFound();
            }
            return View(talent);
        }

        // GET: talents/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.profile, "id", "name");
            return View();
        }

        // POST: talents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,equipment,description,experience")] talent talent)
        {
            if (ModelState.IsValid)
            {
                db.talent.Add(talent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.profile, "id", "name", talent.id);
            return View(talent);
        }

        // GET: talents/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            talent talent = db.talent.Find(id);
            if (talent == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.profile, "id", "name", talent.id);
            return View(talent);
        }

        // POST: talents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,equipment,description,experience")] talent talent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(talent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.profile, "id", "name", talent.id);
            return View(talent);
        }

        // GET: talents/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            talent talent = db.talent.Find(id);
            if (talent == null)
            {
                return HttpNotFound();
            }
            return View(talent);
        }

        // POST: talents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            talent talent = db.talent.Find(id);
            db.talent.Remove(talent);
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
