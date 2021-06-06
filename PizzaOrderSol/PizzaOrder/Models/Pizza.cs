using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaOrder.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaId { get; set; }

        public string Name { get; set; }
        public String Speciality { get; set; }
        public bool Isveg { get; set; }
        public float Price { get; set; }

        public string Image { get; set; }
    }
}