using CARS_DEALER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CARS_DEALER.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.areaName).Include(p => p.coupeType).Include(p => p.doorsType).Include(p => p.engineType).Include(p => p.gearBox).OrderByDescending(p => p.date).Take(5);
            return View(posts.ToList());
        }
    }
}