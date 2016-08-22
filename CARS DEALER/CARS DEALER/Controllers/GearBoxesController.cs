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
    public class GearBoxesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GearBoxes
        public ActionResult Index()
        {
            return View(db.GearBoxes.ToList());
        }

        // GET: GearBoxes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GearBox gearBox = db.GearBoxes.Find(id);
            if (gearBox == null)
            {
                return HttpNotFound();
            }
            return View(gearBox);
        }

        // GET: GearBoxes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GearBoxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,gearType")] GearBox gearBox)
        {
            if (ModelState.IsValid)
            {
                db.GearBoxes.Add(gearBox);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(gearBox);
        }

        // GET: GearBoxes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GearBox gearBox = db.GearBoxes.Find(id);
            if (gearBox == null)
            {
                return HttpNotFound();
            }
            return View(gearBox);
        }

        // POST: GearBoxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,gearType")] GearBox gearBox)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gearBox).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gearBox);
        }

        // GET: GearBoxes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GearBox gearBox = db.GearBoxes.Find(id);
            if (gearBox == null)
            {
                return HttpNotFound();
            }
            return View(gearBox);
        }

        // POST: GearBoxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GearBox gearBox = db.GearBoxes.Find(id);
            db.GearBoxes.Remove(gearBox);
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
