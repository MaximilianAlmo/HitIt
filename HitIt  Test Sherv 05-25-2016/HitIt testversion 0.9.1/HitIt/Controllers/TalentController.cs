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
    public class TalentController : Controller
    {
        private af6947Entities4 db = new af6947Entities4();

        // GET: /Talent/
        public ActionResult Index()
        {
            var talent = db.talent.Include(t => t.profile);
            return View(talent.ToList());
        }

        // GET: /Talent/Details/5
        public ActionResult Details(int? id)
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

        // GET: /Talent/Create
        public ActionResult Create()
        {
            ViewBag.profileid = new SelectList(db.profile, "id", "profileName");
            return View();
        }

        // POST: /Talent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="talentid,profileid,yearsofexperience,talentName,equipment")] talent talent)
        {
            if (ModelState.IsValid)
            {
                db.talent.Add(talent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.profileid = new SelectList(db.profile, "id", "profileName", talent.profileid);
            return View(talent);
        }

        // GET: /Talent/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.profileid = new SelectList(db.profile, "id", "profileName", talent.profileid);
            return View(talent);
        }

        // POST: /Talent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="talentid,profileid,yearsofexperience,talentName,equipment")] talent talent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(talent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.profileid = new SelectList(db.profile, "id", "profileName", talent.profileid);
            return View(talent);
        }

        // GET: /Talent/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: /Talent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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
