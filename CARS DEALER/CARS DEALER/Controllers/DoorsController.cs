using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CARS_DEALER.Models;

namespace CARS_DEALER.Controllers
{
    public class DoorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Doors
        public ActionResult Index()
        {
            return View(db.Doors.ToList());
        }

        // GET: Doors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doors doors = db.Doors.Find(id);
            if (doors == null)
            {
                return HttpNotFound();
            }
            return View(doors);
        }

        // GET: Doors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,doors")] Doors doors)
        {
            if (ModelState.IsValid)
            {
                db.Doors.Add(doors);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(doors);
        }

        // GET: Doors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doors doors = db.Doors.Find(id);
            if (doors == null)
            {
                return HttpNotFound();
            }
            return View(doors);
        }

        // POST: Doors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,doors")] Doors doors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(doors);
        }

        // GET: Doors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doors doors = db.Doors.Find(id);
            if (doors == null)
            {
                return HttpNotFound();
            }
            return View(doors);
        }

        // POST: Doors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doors doors = db.Doors.Find(id);
            db.Doors.Remove(doors);
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
