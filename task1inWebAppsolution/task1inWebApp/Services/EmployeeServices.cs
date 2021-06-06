using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task1inWebApp.Context;
using task1inWebApp.Models;

namespace task1inWebApp.Services
{
    public class EmployeeServices :IUserRepo<Employee>
    {
        private UserContext _context;
        private ILogger<EmployeeServices> _logger;

        public EmployeeServices(UserContext context, ILogger<EmployeeServices> logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool Register(Employee t)
        {
            try
            {
                _context.Employees.Add(t);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
                return false;
            }
        }
        public Employee Get(int id)
        {
            try
            {
                Employee employee = _context.Employees.FirstOrDefault(a => a.Emp_Id == id);
                return employee;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<Employee> GetAll()
        {
            try
            {
                if (_context.Employees.Count() == 0)
                    return null;
                return _context.Employees.ToList();
                //.Include(a => a.Salaries)
                //.ToList();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }
        public bool Login(Employee t)
        {
            try
            {
                Employee employee = _context.Employees.SingleOrDefault(u => u.EmployeeName == t.EmployeeName);
                //if (employee.UserName == t.UserName)
                Console.WriteLine("SALARY:42000,1,20/7/2012");
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}