using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task1inWebApp.Context;
using task1inWebApp.Models;

namespace task1inWebApp.Services
{
    public class SalaryServices : IUserRepo<Salary>
    {
        private UserContext _context;
        private ILogger<SalaryServices> _logger;

        public SalaryServices(UserContext context, ILogger<SalaryServices> logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool Register(Salary t)
        {
            try
            {
                _context.Salaries.Add(t);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return false;
        }
        public void Delete(Salary t)
        {
            throw new NotImplementedException();
        }

        public Salary Get(int id)
        {
            try
            {
                Salary salary = _context.Salaries.FirstOrDefault(a => a.Salary_Id == id);
                return salary;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<Salary> GetAll()
        {
            try
            {
                if (_context.Salaries.Count() == 0)
                    return null;
                return _context.Salaries
                    .ToList();
            }
            catch (Exception e)
            {

                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public void Update(int id, Salary t)
        {
            throw new NotImplementedException();
        }

        public bool Login(Salary t)
        {
            try
            {
                Salary salary = _context.Salaries.SingleOrDefault(u => u.Salary_Id == t.Salary_Id);
                if (salary.Emp_Id == t.Emp_Id)
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }


    }
}