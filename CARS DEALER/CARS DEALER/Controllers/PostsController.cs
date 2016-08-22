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
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.areaName).Include(p => p.Author).Include(p => p.coupeType).Include(p => p.doorsType).Include(p => p.engineType).Include(p => p.gearBox);
            return View(posts.ToList());
        }
        public ActionResult MinePosts()
        {
            
            var posts = db.Posts.Include(p => p.areaName).Include(p => p.Author).Where(p=>p.Author.UserName==User.Identity.Name).Include(p => p.coupeType).Include(p => p.doorsType).Include(p => p.engineType).Include(p => p.gearBox);
           
            return View(posts.ToList());
        }


        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            
            if (post == null)
            {
                return HttpNotFound();
            }
            

            
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.brand_Id = new SelectList(db.Brands, "id", "brandName");
            ViewBag.modelName = new SelectList(db.BrandModels, "id", "modelName");
            ViewBag.area_Id = new SelectList(db.Areas, "id", "area");
            ViewBag.Author_Id = new SelectList(db.Users, "Id", "FullName");
            ViewBag.coupe_Id = new SelectList(db.Coupes, "id", "coupeType");
            ViewBag.doors_Id = new SelectList(db.Doors, "id", "doors");
            ViewBag.engine_Id = new SelectList(db.Engines, "id", "engineType");
            ViewBag.gears_Id = new SelectList(db.GearBoxes, "id", "gearType");
            DateTime end = new DateTime(1900, 1, 1);
            DateTime begin = DateTime.Now;
            List<int> years = new List<int>();
            for (int i = begin.Year; i >= end.Year; i--)
            {
                years.Add(i);
            }
            ViewBag.yearOfProduct = new SelectList(years);
            return View();
           
        }
      
        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
       
       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,brand_Id,model,yearOfProduct,price,kilometers,engine_Id,area_Id,engineVolume,power,coupe_Id,doors_Id,gears_Id,elWindows,airBagsFront,airBagsRear,airBagsSide,bordComputer, phone,clima,parktronic,ABS,leather,tempomat,GPS,DPF,ESP,LPG,description")] Post post)
        {
       
        

            post.EditDate = DateTime.Now;
           
            post.Author = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            post.email = post.Author.Email;
            post.phone = post.Author.PhoneNumber;
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.modelName = new SelectList(db.BrandModels, "id", "modelName", post.modelName);
            ViewBag.brand_Id = new SelectList(db.Brands, "id", "brandName", post.brand_Id);
            ViewBag.area_Id = new SelectList(db.Areas, "id", "area", post.area_Id);
            ViewBag.Author_Id = new SelectList(db.Users, "Id", "FullName", post.Author_Id);
            ViewBag.coupe_Id = new SelectList(db.Coupes, "id", "coupeType", post.coupe_Id);
            ViewBag.doors_Id = new SelectList(db.Doors, "id", "doors", post.doors_Id);
            ViewBag.engine_Id = new SelectList(db.Engines, "id", "engineType", post.engine_Id);
            ViewBag.gears_Id = new SelectList(db.GearBoxes, "id", "gearType", post.gears_Id);
            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.modelName = new SelectList(db.BrandModels, "id", "modelName", post.modelName);
            ViewBag.brand_Id = new SelectList(db.Brands, "id", "brandName", post.brand_Id);
            ViewBag.area_Id = new SelectList(db.Areas, "id", "area", post.area_Id);
            ViewBag.Author_Id = new SelectList(db.Users, "Id", "FullName", post.Author_Id);
            ViewBag.coupe_Id = new SelectList(db.Coupes, "id", "coupeType", post.coupe_Id);
            ViewBag.doors_Id = new SelectList(db.Doors, "id", "doors", post.doors_Id);
            ViewBag.engine_Id = new SelectList(db.Engines, "id", "engineType", post.engine_Id);
            ViewBag.gears_Id = new SelectList(db.GearBoxes, "id", "gearType", post.gears_Id);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,brand_Id,modelName,yearOfProduct,price,kilometers,engine_Id,area_Id,engineVolume,power,coupe_Id,doors_Id,gears_Id,elWindows,airBagsFront,airBagsRear,airBagsSide,bordComputer,email,phone,clima,parktronic,ABS,leather,tempomat,GPS,DPF,isSold,ESP,LPG,description,date,EditDate,Author_Id")] Post post)
        {
            post.EditDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                if(post.isSold == true)
                {
                    DeleteConfirmed(post.Id);
                }else
                {
                    db.Entry(post).State = EntityState.Modified;
                    db.Entry(post).Property(p => p.date).IsModified = false;
                }
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.area_Id = new SelectList(db.Areas, "id", "area", post.area_Id);
            ViewBag.Author_Id = new SelectList(db.Users, "Id", "FullName", post.Author_Id);
            ViewBag.coupe_Id = new SelectList(db.Coupes, "id", "coupeType", post.coupe_Id);
            ViewBag.doors_Id = new SelectList(db.Doors, "id", "doors", post.doors_Id);
            ViewBag.engine_Id = new SelectList(db.Engines, "id", "engineType", post.engine_Id);
            ViewBag.gears_Id = new SelectList(db.GearBoxes, "id", "gearType", post.gears_Id);
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
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
