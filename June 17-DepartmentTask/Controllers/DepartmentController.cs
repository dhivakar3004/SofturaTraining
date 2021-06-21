using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DepartmentTask.Models;
namespace DepartmentTask.Controllers
{
    public class DepartmentController : Controller
    {
        //GET: Home
        public ActionResult Index()
        {
            using (AdventureWorks2019Entities1 dept = new AdventureWorks2019Entities1())
            {

                var res = new SelectList((from d in dept.Departments
                                          select d).ToList(), "DepartmentID", "Name");
                ViewData["Departments"] = res;



            }
            return View();

        }

        
        public ActionResult EmpDept(FormCollection form, string action)
        {
            if (action == "Submit")
            {
                DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection("Data source=LAPTOP-874O3SVO\\SQLEXPRESS;database=AdventureWorks2019;integrated security=true");
                string name = form["Departments"];
                int id = Convert.ToInt32(name);
                SqlCommand cmd = new SqlCommand("select per.BusinessEntityID,DepartmentID,FirstName,BirthDate,MaritalStatus,Gender,HireDate " +
                    "from HumanResources.Employee emp " +
                    "join Person.Person per on emp.BusinessEntityID = per.BusinessEntityID " +
                    "join HumanResources.EmployeeDepartmentHistory empdep " +
                    "on per.BusinessEntityID = empdep.BusinessEntityID where DepartmentID=" + id, con);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                return View(dt);
            }
            else
            {
                return RedirectToAction("Index");
            }

            
        }

       
    }
}