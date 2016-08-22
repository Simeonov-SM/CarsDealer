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
    public class BrandModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BrandModels
        public ActionResult Index()
        {
            return View(db.BrandModels.ToList());
           // var brandModels = db.BrandModels.Include(b => b.brand.brandName).Where(b => b.brand.id == b.brand_Id);
            //return View(brandModels.ToList());
        }

        // GET: BrandModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrandModel brandModel = db.BrandModels.Find(id);
            if (brandModel == null)
            {
                return HttpNotFound();
            }
            return View(brandModel);
        }

        // GET: BrandModels/Create
        public ActionResult Create()
        {
            ViewBag.brand_Id = new SelectList(db.Brands, "id", "brandName");
            return View();
        }

        // POST: BrandModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,modelName,brand_Id")] BrandModel brandModel)
        {
            if (ModelState.IsValid)
            {
                db.BrandModels.Add(brandModel);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.brand_Id = new SelectList(db.Brands, "id", "brand", brandModel.brand_Id);
            return View(brandModel);
        }

        // GET: BrandModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrandModel brandModel = db.BrandModels.Find(id);
            if (brandModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.brand_Id = new SelectList(db.Brands, "id", "brand", brandModel.brand_Id);
            return View(brandModel);
        }

        // POST: BrandModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,modelName,brand_Id")] BrandModel brandModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brandModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.brand_Id = new SelectList(db.Brands, "id", "brand", brandModel.brand_Id);
            return View(brandModel);
        }

        // GET: BrandModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrandModel brandModel = db.BrandModels.Find(id);
            if (brandModel == null)
            {
                return HttpNotFound();
            }
            return View(brandModel);
        }

        // POST: BrandModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BrandModel brandModel = db.BrandModels.Find(id);
            db.BrandModels.Remove(brandModel);
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
