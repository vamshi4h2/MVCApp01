using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using MVCApp1.Models;

namespace MVCApp1.Controllers
{
    public class AdoController : Controller
    {


        // LAPTOP-8TV0R1QK\SQLEXPRESS


        SqlConnection cn = new SqlConnection(@"server=LAPTOP-8TV0R1QK\SQLEXPRESS;user id=sa;password=SQLserver@418;database=AdoDb;MultipleActiveResultSets=true");

        string query = string.Empty;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        List<Employee> employees = new List<Employee>();
        public AdoController()
        {


            cn.Open();
            query = "select * from tblEmployees";
            cmd = new SqlCommand(query, cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Employee e1 = new Employee();
                e1.Id = Convert.ToInt32(dr[0]);
                e1.Ename = dr[1].ToString();
                e1.Job = dr[2].ToString();
                e1.Salary = Convert.ToInt32(dr[3]);
                employees.Add(e1);
            }
        }
        // GET: Ado
        [HttpGet]
        public ActionResult Index()
        {

            if (cn.State == ConnectionState.Open)
                ViewBag.msg = "Connection established successfully..";
            return View();
        }

        public ActionResult EmpList()
        {
            ViewBag.employees = employees;

            return View();
        }
        public ActionResult Details(int id)
        {
            Employee empid = employees.SingleOrDefault(x => x.Id == id);
            ViewBag.empid = empid;

            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(int id, string ename, string job, int salary, string b1)
        {
            // cs = @"server=LAPTOP-8TV0R1QK\SQLEXPRESS;user id=sa;password=SQLserver@418;database=AdoDb;MultipleActiveResultSets=true";
            //  SqlConnection cn1 = new SqlConnection(cs);

            string query1 = "insert into tblEmployees values (@id,@ename,@job,@salary)";
            SqlCommand cmd1 = new SqlCommand(query1, cn);
            cmd1.Parameters.AddWithValue("@id", id);
            cmd1.Parameters.AddWithValue("@ename", ename);
            cmd1.Parameters.AddWithValue("@job", job);
            cmd1.Parameters.AddWithValue("@salary", salary);

            cmd1.ExecuteNonQuery();
            ViewBag.msg1 = "Row added Successfully..";

            return RedirectToAction("EmpList");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Employee e = employees.SingleOrDefault(x => x.Id == id);
            ViewBag.e = e;
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id, string b2)
        {
            string query2 = "delete tblEmployees  where id=@id";
            SqlCommand cmd2 = new SqlCommand(query2, cn);
            cmd2.Parameters.AddWithValue("@id", id);

            cmd2.ExecuteNonQuery();

            ViewBag.msg2 = "Row deleted sucessfully...";


            return RedirectToAction("EmpList");
        }
        public ActionResult Edit(int id)
        {
            Employee e = employees.SingleOrDefault(x => x.Id == id);
            ViewBag.e = e;
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id,string ename,string job,int salary, string b3)
        {
            string query3 = "update tblEmployees set ename=@ename,job=@job,salary=@salary where id=@id";
            SqlCommand cmd3 = new SqlCommand(query3, cn);
            cmd3.Parameters.AddWithValue("@id", id);
            cmd3.Parameters.AddWithValue("@ename", ename);
            cmd3.Parameters.AddWithValue("@job", job);
            cmd3.Parameters.AddWithValue("@salary", salary);

            cmd3.ExecuteNonQuery();

            ViewBag.msg3 = "Row Updated sucessfully...";


            return RedirectToAction("EmpList");
        }


    }
}
