using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using task1inWebApp.Models;

namespace task1inWebApp.Context

{
    public class UserContext : DbContext
    {
        public UserContext()
        {
        }

        public UserContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasData(
                new UserModel() { UserName="Dhiva" ,Password="1234" });        
        
            modelBuilder.Entity<UserModel>().HasData(
                new Employee() { Emp_Id = 1, EmployeeName = "Dhiva", UserName = "Dhiv", Age = 24 });
        
            modelBuilder.Entity<UserModel>().HasData(
                new Salary() { Salary_Id = 100, salary_ = 42000, date = "20/7/2012", Emp_Id = 1 });
        }
    }
}