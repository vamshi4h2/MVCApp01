using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCApp1.Models;

namespace MVCApp1.Controllers
{
    public class students1Controller : Controller
    {
        private AdoDbEntities1 db = new AdoDbEntities1();

        // GET: students1
        public ActionResult Index()
        {
            var students1 = db.students1.Include(s => s.course);
            return View(students1.ToList());
        }

        // GET: students1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students students = db.students1.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // GET: students1/Create
        public ActionResult Create()
        {
            ViewBag.courseid = new SelectList(db.courses1, "id", "coursename");
            return View();
        }

        // POST: students1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ids,sname,courseid")] students students)
        {
            if (ModelState.IsValid)
            {
                db.students1.Add(students);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.courseid = new SelectList(db.courses1, "id", "coursename", students.courseid);
            return View(students);
        }

        // GET: students1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students students = db.students1.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            ViewBag.courseid = new SelectList(db.courses1, "id", "coursename", students.courseid);
            return View(students);
        }

        // POST: students1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ids,sname,courseid")] students students)
        {
            if (ModelState.IsValid)
            {
                db.Entry(students).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.courseid = new SelectList(db.courses1, "id", "coursename", students.courseid);
            return View(students);
        }

        // GET: students1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students students = db.students1.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // POST: students1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            students students = db.students1.Find(id);
            db.students1.Remove(students);
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
