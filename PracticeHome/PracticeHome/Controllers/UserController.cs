using PracticeHome.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeHome.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var db = new Entities();
            var data = db.users.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult createUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult createUser(user u) {
            var db = new Entities();
            db.users.Add(u);
            db.SaveChanges();
            //return RedirectToAction("Index");
            return View();
        }
        public ActionResult detailsUser( )
        {
            var db = new Entities();
            
            return View(db);
        }
    }
}