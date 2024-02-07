using Form_validation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace Form_validation.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Person());
        }
        [HttpPost]
        public ActionResult Index(Person p){

            if (ModelState.IsValid)
            { //checking the rules imposed in Person class
                return RedirectToAction("About");
            }
            return View(p);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}