using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp1.Controllers
{

       // PostBack/Index

    public class PostBackController : Controller
    {
        // GET: PostBack
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.msg = "Hello, welcome";
            return View();
        }
        [HttpPost]
        public ActionResult Index(string b1)
        {
            ViewBag.msg =b1   +  "  Clicked";
            return View();
        }
        [HttpGet]
        public ActionResult Ex01()
        {
            ViewBag.msg = "Hello, welcome";
            return View();
        }
        [HttpPost]
        public ActionResult Ex01(string name)
        {
            ViewBag.msg = "H!, "+name;
            return View();
        }
        [HttpGet]
        public ActionResult Ex02()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Ex02(int a,int b,string b1)
        {
            int c = 0;
            switch (b1)
            {
                case "Addition":
                    c = a + b;
                    break;
                case "Subtraction":
                    c = a - b;
                    break;
                case "Multiplication":
                    c = a * b;
                    break;
                case "Division":
                    c = a / b;
                    break;
            }
            ViewBag.msg = $"{b1} of {a} and {b} is {c}";
            return View();
        }
    }
}