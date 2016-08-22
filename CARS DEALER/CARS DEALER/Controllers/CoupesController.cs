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
    public class CoupesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Coupes
        public ActionResult Index()
        {
            return View(db.Coupes.ToList());
        }

        // GET: Coupes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupe coupe = db.Coupes.Find(id);
            if (coupe == null)
            {
                return HttpNotFound();
            }
            return View(coupe);
        }

        // GET: Coupes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coupes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,coupeType")] Coupe coupe)
        {
            if (ModelState.IsValid)
            {
                db.Coupes.Add(coupe);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(coupe);
        }

        // GET: Coupes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupe coupe = db.Coupes.Find(id);
            if (coupe == null)
            {
                return HttpNotFound();
            }
            return View(coupe);
        }

        // POST: Coupes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,coupeType")] Coupe coupe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coupe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coupe);
        }

        // GET: Coupes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupe coupe = db.Coupes.Find(id);
            if (coupe == null)
            {
                return HttpNotFound();
            }
            return View(coupe);
        }

        // POST: Coupes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coupe coupe = db.Coupes.Find(id);
            db.Coupes.Remove(coupe);
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
