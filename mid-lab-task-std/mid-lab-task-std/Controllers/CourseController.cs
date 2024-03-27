using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mid_lab_task_std.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}