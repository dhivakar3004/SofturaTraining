using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Book

    {
        public int Id { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public int Author_Id {get; set; }
    }
}