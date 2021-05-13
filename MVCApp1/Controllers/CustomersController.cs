using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCApp1.Models;
namespace MVCApp1.Controllers
{
    public class CustomersController : Controller
    {
        static List<CustomerModel> customers= new List<CustomerModel>
        {
            new CustomerModel{Id=1001,Cname="rahul",Email="rahul@gmail.com",City="bnglr"},
            new CustomerModel{Id=1002,Cname="rohit",Email="rohit3@gmail.com",City="hyd"}
        };

        // GET: Customers
        public ActionResult Index()
        {
            return View(customers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            return View(customers.Single(x => x.Id == id));
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(CustomerModel c1)
        {
            try
            {
                // TODO: Add insert logic here
                customers.Add(c1);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            return View(customers.Single(x => x.Id == id));
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,CustomerModel c1)
        {
            try
            {
                // TODO: Add update logic here
                int index = customers.FindIndex(x => x.Id == id);
                customers[index] = c1;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            return View(customers.Single(x => x.Id == id));
        }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,CustomerModel c1)
        {
            try
            {
                // TODO: Add delete logic here
                int index = customers.FindIndex(x => x.Id == id);
                customers.RemoveAt(index);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
