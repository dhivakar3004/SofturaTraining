using EFCOREEG.pubs;
using System;
using System.Linq;

namespace EFCOREEG
{
    class Program
    {
        public static pubsContext db = new pubsContext();
        //static void Main(string[] args)
        //{
        //    Employees emp = AcceptData();
        //    InsertData(emp);
        //    Console.WriteLine("Record added Successfully");
        //    SelectDataMethod();
        //}
        private static void SelectDataMethod()
        {
            var result = db.Employees.ToList();
            foreach (var item in result)
            {
                Console.WriteLine(item.Fname + " " + item.Lname + " " + item.HireDate);
            }
        }

        private static void InsertData(Employees em)
        {
            db.Employees.Add(em);
            db.SaveChanges();
        }
        private static Employees AcceptData()
        {
            Console.WriteLine("Enter fname,minit,lname");
            Employees e = new Employees();          
            e.Fname = Console.ReadLine();
            e.Minit = Console.ReadLine();
            e.Lname = Console.ReadLine();
            return e;
        }
    }
}
