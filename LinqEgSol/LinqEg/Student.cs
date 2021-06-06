using System;
using System.Collections.Generic;
using System.Text;

namespace LinqEg
{
    class Student
    { 
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public float Marks { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
        public Student()
        {

        }
        public Student(int sid,string sname,float marks,DateTime doj,string city)
        {
            StudentId = sid;
            StudentName = sname;
            Marks = marks;
            DOJ = doj;
            City = city;
        }
        public override string ToString()
        {
            return string.Format(StudentId + "  " + StudentName + " " + Marks + " " + DOJ + " " + City);
        }


    }
}
