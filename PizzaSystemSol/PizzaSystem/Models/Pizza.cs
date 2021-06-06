using System.ComponentModel.DataAnnotations;
using System;

namespace PizzaSystem.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaId { get; set; }
        [Required]
        public string PizzaName { get; set; }
        [Required]
        public string Speciality { get; set; }
        [Required]
        public bool IsVeg { get; set; }
        [Required]
        public double Price { get; set; }
       
    }
}