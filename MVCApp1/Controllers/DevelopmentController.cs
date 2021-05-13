using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp1.Controllers
{
    public class DevelopmentController : Controller
    {
        // GET: Development
        public ActionResult Index()
        {
            ViewBag.Message = "your Development page";
            return View();
        }
        
        public ActionResult Domains()
        {
            
            return View();
        }
        public ActionResult Developers()
        {
            
            return View();

        }

    }
}