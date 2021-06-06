using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransportBLLibrary;
using TransportDALLibrary;

namespace TransportFEApplication
{
    class EmployeeManagement
    {
        private IRepo<Employee> _repo;
        public EmployeeManagement()
        {

        }
        public EmployeeManagement(IRepo<Employee> repo)
        {
            _repo = repo;
        }
        public void CreateEmployee()
        {
            CompleteEmployee employee = new CompleteEmployee();
            employee.TakeEmployeeData();
            try
            {
                if(_repo.Add(employee))
                    Console.WriteLine("Employee created");
                else
                    Console.WriteLine("Not Created");

            }
            catch (Exception e)
            {

                Console.WriteLine("Could not add employee");
                Console.WriteLine(e.Message);
            }
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = _repo.GetAll().ToList();
            return employees;

        }
        public void printAllEmployee()
        {
            var employees = GetAllEmployees();
            foreach(Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        public List<CompleteEmployee> SortEmployees()
        {
           List<CompleteEmployee> employees = new List<CompleteEmployee>();
            foreach (var item in GetAllEmployees())
            {
                employees.Add(new CompleteEmployee(item));
            }return employees;

           
        }

        public void printEmployeeSortedById()
        {
            var employees = SortEmployees();
            employees.Sort();
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
        public void ResetPassword()
        {
            Employee employee = new Employee();
            Console.WriteLine("Please enter the employee id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the old password");
            string password = Console.ReadLine();
            Employee employee1 = GetAllEmployees().Find(match: e => e.Id == id && e.Password == password);
            try
            {
                if(employee != null)
                {
                    Console.WriteLine("Please enter the new password");
                    var newPassword = Console.ReadLine();
                    Console.WriteLine("Please Retype the new password");
                    var repeatPassword = Console.ReadLine();
                    if(newPassword == repeatPassword )
                    {
                        employee.Password = newPassword;
                        if(_repo.Update(employee))
                            Console.WriteLine("password updated");
                        else
                            Console.WriteLine("Password not updated. Please Try again");
                    }
                    else
                        Console.WriteLine("Password mismatch");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Could not update the password ar this time");
                Console.WriteLine(e.Message);
            }
        }
    }
}
