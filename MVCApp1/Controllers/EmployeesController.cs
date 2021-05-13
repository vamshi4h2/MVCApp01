using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCApp1.Models;

namespace MVCApp1.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        static List<Employee> employees = new List<Employee>
        {
            new Employee{Id=1009,Ename="rahul",Job="developer",Salary=4000},
            new Employee{Id=1008,Ename="rohit",Job="developer",Salary=4000}
        };
        public ActionResult Index()
        {
            return View(employees);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            return View(employees.Single(x=>x.Id==id));
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee e)
        {
            try
            {
                // TODO: Add insert logic here
                employees.Add(e);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            return View(employees.Single(x=>x.Id==id));
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee e)
        {
            try
            {
                // TODO: Add update logic here
                int index = employees.FindIndex(x => x.Id == id);
                employees[index] = e;
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            return View(employees.Single(x => x.Id == id));
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                int index = employees.FindIndex(x => x.Id == id);
                employees.RemoveAt(index);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
