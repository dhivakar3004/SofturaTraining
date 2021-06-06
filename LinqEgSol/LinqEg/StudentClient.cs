using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqEg
{
    public class StudentClient
    {
        public static void Main()
        {
            //    List<Student> students = new List<Student>();
            //    //students.Add(new Student(1, "Ram", 34, DateTime.Now, "Chennai"));
            //    //students.Add(new Student(2, "Arun", 75, DateTime.Now, "Trichy"));
            //    //students.Add(new Student(3, "Balaji", 66, DateTime.Now, "Coimbatore"));
            //    //students.Add(new Student(4, "Surya", 67, DateTime.Now, "Madurai"));
            //    //students.Add(new Student(5, "Vijay", 78, DateTime.Now, "Pudukottai"));
            //    //students.Add(new Student(6, "Raina", 89, DateTime.Now, "Gujarat"));
            //    //students.Add(new Student(7, "Dhoni", 60, DateTime.Now, "Ranchi"));

            //    Console.WriteLine("Enter the number of students");
            //    int size = Convert.ToInt32(Console.ReadLine());
            //    for (int i = 0; i < size; i++)
            //    {
            //        Student s = new Student();
            //        Console.WriteLine("Enter student id,name,marks,doj and city");
            //        s.StudentId = Convert.ToInt32(Console.ReadLine());
            //        s.StudentName = (Console.ReadLine());
            //        s.Marks=Convert.ToInt32(Console.ReadLine());
            //        s.DOJ = Convert.ToDateTime(Console.ReadLine());
            //        s.City = Console.ReadLine();
            //        students.Add(s);

            //    }
            //    var result = (from i in students
            //                  where i.Marks > 65
            //                  select i).ToList();
            //    foreach (var item in result)
            //    {
            //        Console.WriteLine(item.ToString());
            //    }

            //    Console.WriteLine("Enter the city to be searched");
            //    string seacity = Console.ReadLine();
            //    #region
            //    //Querey syntax

            //    //var res = (from i in students
            //    //           where i.City == seacity
            //    //           select i).ToList();
            //    #endregion

            //    //Method syntax

            //    var res2 = students.Where(i => i.Marks > 60 && i.City == seacity).Select(i => i).ToList();
            //    foreach (var item in res2)
            //    {
            //        Console.WriteLine(item.ToString());
            //    }


            //    Console.WriteLine("enter the id to be searched");
            //    int sid = Convert.ToInt32(Console.ReadLine());
            //    var res1 = (from i in students
            //                where i.StudentId == sid
            //                select i).FirstOrDefault();
            //    Console.WriteLine(res1.ToString());



        }
    }

}