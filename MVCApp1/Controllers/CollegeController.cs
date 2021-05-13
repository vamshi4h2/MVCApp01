using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp1.Controllers
{
    public class CollegeController : Controller
    {
        // GET: College
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Courses()
        {
            return View();
        }
        public ActionResult Staff()
        {
            return View();
        }
        public ActionResult Facilities()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
    }
}