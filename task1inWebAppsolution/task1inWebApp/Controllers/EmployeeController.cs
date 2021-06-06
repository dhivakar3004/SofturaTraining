using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using task1inWebApp.Models;
using task1inWebApp.Services;

namespace task1inWebApp.Controllers
{
    public class EmployeeController :Controller
    {
        private ILogger<EmployeeController> _logger;
        private IUserRepo<Employee> _repo;
        public EmployeeController(IUserRepo<Employee> repo, ILogger<EmployeeController> logger)
        {
            _logger = logger;
            _repo = repo;
        }
        public IActionResult Index()
        {
            List<Employee> employees = _repo.GetAll().ToList();
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            try
            {
                _repo.Register(employee);
                TempData["un"] = employee.EmployeeName;
                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Login()
        {
            //if (TempData.Count == 0)
            //return View();
            //Employee employee = new Employee();
            //employee.EmployeeName = TempData.Peek("un").ToString();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Employee employee)
        {
            try
            {
                if (_repo.Login(employee))
                    // _repo.Login(employee);
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            return View();
        }
    }
}