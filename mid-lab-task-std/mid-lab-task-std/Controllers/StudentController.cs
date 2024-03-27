using mid_lab_task_std.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mid_lab_task_std.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [HttpGet]
        public ActionResult createIndex()
        {
            return View(new Student());
        }
        [HttpPost]
        public ActionResult createIndex(Student s)
        {
            if (ModelState.IsValid)
            { //checking the rules imposed in Person class
                //TempData["Msg"] = "Form is valid";
                var db = new Entities();
                db.Students.Add(s);
                db.SaveChanges();
                return RedirectToAction("Contact");
            }
            return View(s);
        }
    }
}